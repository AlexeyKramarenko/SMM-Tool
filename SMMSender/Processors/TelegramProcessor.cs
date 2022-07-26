using SMMSender.DTO;
using SMMSender.Constants;
using SMMSender.Utils;
using SMMSender.Utils.WindowsApi;
using static SMMSender.Utils.WindowsApi.WinApi;

namespace SMMSender.Processors
{
    internal class TelegramProcessor : DesktopAppProcessorBase, IProcessor
    {

        private readonly FormDto _formDto;
        private readonly WinApiWrapper _winApi;
        private readonly TelegramControlsCoords _coords;
        private IntPtr _telegramHwnd;

        public TelegramProcessor(
                        WinApiWrapper winApi,
                        FormDto formDto,
                        TelegramControlsCoords coords)
        {
            _formDto = formDto;
            _winApi = winApi;
            _coords = coords;
        }

        public void Send()
        {
            Run();
            InitHandler(WindowClass.Telegram, out _telegramHwnd);
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
                processName: "telegram",
                filePath: $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\Telegram Desktop\\Telegram.exe");

            base.Run(dto);
        }


        private void PlaceWindowToTheTopLeftCorner() =>
            _winApi
                .SetWindowPos(_telegramHwnd, new POINT(0, 0), width: 1400, height: 800)
                .Wait(500);


        private void ClickOnTheFirstChatAtTheTop() =>
            _winApi
                .MouseLeftClick(_coords.FirstChat);


        private void ChooseImage() =>
            _winApi
                .Wait(1500)
                .SendKeys(
                     VirtualKeyStates.VK_CONTROL,
                     VirtualKeyStates.O_key)
                .Wait(1000)
                .SendKeys(
                     VirtualKeyStates.VK_CONTROL,
                     VirtualKeyStates.L_key)
                .Wait(200)
                .SendText(_telegramHwnd, UploadedData.FolderPath)
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(200)
                .SendKeys(
                     VirtualKeyStates.VK_MENU,
                     VirtualKeyStates.N_key)
                .Wait()
                .SendText(_telegramHwnd, UploadedData.FileName + FileExtensions.Jpg)
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(1000);


        private void AddTextContent() =>
            _winApi
                .SendText(_telegramHwnd, _formDto.Body);


        private void ClickSendBtn() =>
            _winApi
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(1000);


        private void Close() =>
            _winApi
                .SendKeys(
                     VirtualKeyStates.VK_MENU,
                     VirtualKeyStates.VK_F4);

        #endregion

    }
}
