using SMMSender.DTO;
using SMMSender.Constants;
using SMMSender.Utils;
using SMMSender.Utils.WindowsApi;
using static SMMSender.Utils.WindowsApi.WinApi;

namespace SMMSender.Processors
{
    internal class ViberProcessor : DesktopAppProcessorBase, IProcessor
    {
        private readonly ViberControlsCoords _coords;
        private readonly WinApiWrapper _winApi;
        private readonly FormDto _formDto;
        private IntPtr _viberHwnd;

        public ViberProcessor(
                        WinApiWrapper winApi,
                        FormDto formDto,
                        ViberControlsCoords viberElementsCoords)
        {
            _winApi = winApi;
            _formDto = formDto;
            _coords = viberElementsCoords;
        }

        public void Send()
        {
            Run();
            InitHandler(WindowClass.Viber, out _viberHwnd);
            PlaceWindowToTheTopLeftCorner();
            ClickOnTheFirstChatAtTheTop();
            ChooseImage();
            AddTextContent();
            ClickSendBtn();
            //Close();
        }

        #region Private Methods

        private void Run()
        {
            var dto = new ProcessDto(
                processName: "viber",
                filePath: $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Viber\\Viber.exe");

            base.Run(dto);
        }


        private void PlaceWindowToTheTopLeftCorner() =>
            _winApi
                .SetWindowPos(_viberHwnd, new POINT(0, 0), width: 1400, height: 800)
                .Wait(1500);


        private void ClickOnTheFirstChatAtTheTop() =>
            _winApi
                .MouseLeftClick(_coords.FirstChat);


        private void ChooseImage() =>
            _winApi
                .Wait(2000)
                .MouseLeftClick(_coords.UploadImageBtn)
                .Wait(3000)
                .SendKeys(VirtualKeyStates.VK_CONTROL, VirtualKeyStates.L_key)
                .SendText(_viberHwnd, UploadedData.FolderPath)
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(2000)
                .SendKeys(
                    VirtualKeyStates.VK_MENU,
                    VirtualKeyStates.N_key)
                .SendText(_viberHwnd, UploadedData.FileName + FileExtensions.Jpg)
                .SendKey(VirtualKeyStates.VK_RETURN);


        private void AddTextContent() =>
            _winApi
                .Wait(300)
                .MouseLeftClick(_coords.TextContent)
                .Wait(500)
                .MouseRightClick(_coords.TextContent)
                .Wait(500)
                .SendKey(VirtualKeyStates.VK_DOWN)
                .SendKey(VirtualKeyStates.VK_DOWN)
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(300)
                .SendText(_viberHwnd, _formDto.Body)
                .SendKey(VirtualKeyStates.VK_RETURN);


        private void ClickSendBtn() =>
            _winApi
                .SendKey(VirtualKeyStates.VK_RETURN);


        private void Close() =>
            _winApi
                .Wait(1000)
                .SendKeyDown(VirtualKeyStates.VK_MENU)
                .SendKey(VirtualKeyStates.VK_F4)
                .SendKeyUp(VirtualKeyStates.VK_MENU);

        #endregion

    }
}
