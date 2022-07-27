using SMMSender.DTO;
using SMMSender.Constants;
using SMMSender.Utils;
using SMMSender.Utils.WindowsApi;
using static SMMSender.Utils.WindowsApi.WinApi;
using SMMSender.Factories.Implementations;

namespace SMMSender.Processors.Implementations
{
    internal class ViberProcessor : DesktopAppProcessorBase, IProcessor
    {

        private readonly ViberDependenciesFactory _factory;

        public ViberProcessor(ViberDependenciesFactory factory)
        {
            _factory = factory;
        }

        public void Send()
        {
            var winApi = _factory.CreateWinApiObject();
            var formDto = _factory.CreateFormObject();
            var coords = _factory.CreateViberControlsCoords();
            var process = _factory.CreateProcessDto();

            Run(process);

            IntPtr hwnd = InitHandler(WindowClass.Viber);

            PlaceWindowToTheTopLeftCorner(winApi, hwnd);
            ClickOnTheFirstChatAtTheTop(winApi, coords);
            ChooseImage(winApi, coords, hwnd);
            AddTextContent(winApi, coords, formDto, hwnd);
            ClickSendBtn(winApi);
            Close(winApi);
        }

        #region Private Methods 

        private void PlaceWindowToTheTopLeftCorner(WinApiWrapper winApi, IntPtr hwnd) =>
            winApi
                .SetWindowPos(hwnd, new POINT(0, 0), width: 1400, height: 800)
                .Wait(1500);


        private void ClickOnTheFirstChatAtTheTop(WinApiWrapper winApi, ViberControlsCoords coords) =>
            winApi
                .MouseLeftClick(coords.FirstChat);


        private void ChooseImage(WinApiWrapper winApi, ViberControlsCoords coords, IntPtr hwnd) =>
            winApi
                .Wait(2000)
                .MouseLeftClick(coords.UploadImageBtn)
                .Wait(3000)
                .SendKeys(VirtualKeyStates.VK_CONTROL, VirtualKeyStates.L_key)
                .SendText(hwnd, UploadedData.FolderPath)
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(2000)
                .SendKeys(
                    VirtualKeyStates.VK_MENU,
                    VirtualKeyStates.N_key)
                .SendText(hwnd, UploadedData.FileName + FileExtensions.Jpg)
                .SendKey(VirtualKeyStates.VK_RETURN);


        private void AddTextContent(WinApiWrapper winApi, ViberControlsCoords coords, FormDto form, IntPtr hwnd) =>
            winApi
                .Wait(300)
                .MouseLeftClick(coords.TextContent)
                .Wait(500)
                .MouseRightClick(coords.TextContent)
                .Wait(500)
                .SendKey(VirtualKeyStates.VK_DOWN)
                .SendKey(VirtualKeyStates.VK_DOWN)
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(300)
                .SendText(hwnd, form.Body)
                .SendKey(VirtualKeyStates.VK_RETURN);


        private void ClickSendBtn(WinApiWrapper winApi) =>
            winApi
                .SendKey(VirtualKeyStates.VK_RETURN);


        private void Close(WinApiWrapper winApi) =>
            winApi
                .Wait(1000)
                .SendKeyDown(VirtualKeyStates.VK_MENU)
                .SendKey(VirtualKeyStates.VK_F4)
                .SendKeyUp(VirtualKeyStates.VK_MENU);

        #endregion

    }
}
