using SMMSender.DTO;
using SMMSender.Constants;
using SMMSender.Utils;
using SMMSender.Utils.WindowsApi;
using static SMMSender.Utils.WindowsApi.WinApi;
using SMMSender.Factories;

namespace SMMSender.Processors.Implementations
{
    internal class TelegramProcessor : DesktopAppProcessorBase, IProcessor
    {

        private readonly ITelegramDependenciesFactory _factory;

        public TelegramProcessor(ITelegramDependenciesFactory factory)
        {
            _factory = factory;
        }

        public void Send()
        {
            var winApi = _factory.CreateWinApiObject();
            var form = _factory.CreateFormObject();
            var coords = _factory.CreateTelegramControlsCoords();
            var process = _factory.CreateProcessDto();

            Run(process);

            IntPtr hwnd = InitHandler(WindowClass.Telegram);

            PlaceWindowToTheTopLeftCorner(winApi, hwnd);
            ClickOnTheFirstChatAtTheTop(winApi, coords);
            ChooseImage(winApi, hwnd);
            AddTextContent(winApi, form, hwnd);
            ClickSendBtn(winApi);
            Close(winApi);
        }


        #region Private Methods

        private WinApiWrapper PlaceWindowToTheTopLeftCorner(
                                                    WinApiWrapper winApi,
                                                    IntPtr hwnd) =>
            winApi
              .SetWindowPos(hwnd, new POINT(0, 0), width: 1400, height: 800)
              .Wait(500);


        private WinApiWrapper ClickOnTheFirstChatAtTheTop(
                                         WinApiWrapper winApi,
                                         TelegramControlsCoords coords) => winApi.MouseLeftClick(coords.FirstChat);


        private void ChooseImage(WinApiWrapper winApi, IntPtr hwnd) =>
            winApi
                .Wait(1500)
                .SendKeys(
                     VirtualKeyStates.VK_CONTROL,
                     VirtualKeyStates.O_key)
                .Wait(1000)
                .SendKeys(
                     VirtualKeyStates.VK_CONTROL,
                     VirtualKeyStates.L_key)
                .Wait(200)
                .SendText(hwnd, UploadedData.FolderPath)
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(200)
                .SendKeys(
                     VirtualKeyStates.VK_MENU,
                     VirtualKeyStates.N_key)
                .Wait()
                .SendText(hwnd, UploadedData.FileName + FileExtensions.Jpg)
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(1000);


        private void AddTextContent(WinApiWrapper winApi, FormDto formDto, IntPtr hwnd) =>
            winApi.SendText(hwnd, formDto.Body);


        private void ClickSendBtn(WinApiWrapper winApi) =>
            winApi
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(1000);


        private void Close(WinApiWrapper winApi) =>
            winApi
               .SendKeys(
                    VirtualKeyStates.VK_MENU,
                    VirtualKeyStates.VK_F4);

        #endregion

    }
}
