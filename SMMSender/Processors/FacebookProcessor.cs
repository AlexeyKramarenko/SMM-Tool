using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SMMSender.Constants;
using SMMSender.DTO;
using SMMSender.Utils;
using SMMSender.Utils.WindowsApi;
using static SMMSender.Utils.FunctionalWrapper;
using static SMMSender.Utils.WindowsApi.WinApi;

namespace SMMSender.Processors
{
    internal class FacebookProcessor : DesktopAppProcessorBase, IProcessor
    {
        private readonly WinApiWrapper _winApi;
        private readonly FormDto _formDto;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private IntPtr _dialogHwnd;

        public FacebookProcessor(WinApiWrapper winApi, FormDto formDto)
        {
            _winApi = winApi;
            _formDto = formDto;
            _driver = new ChromeDriver();

            _driver
                .Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(10);

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

        public void Send()
        {
            InitHandler(WindowClass.OpenFileDialog, out _dialogHwnd);
            OpenPage();
            CreateArticle();
            CheckInstagramCheckBox();
            AddTextContent();
            AddImage();
            ClickSendBtn();
        }

        #region Private Methods

        private void OpenPage()
        {
            string url = "www.facebook.com/ic.misto/publishing_tools/";

            _driver
                .Navigate()
                .GoToUrl(url);
        }


        private void CreateArticle()
        {
            IWebElement? btn =
                _wait.Until(d => _driver.FindElements(FacebookElementsCoords.ArticleBtn)
                                         .FirstOrDefault());
            btn.Click();
        }

        private void CheckInstagramCheckBox()
        {
            IWebElement? chkBox =
                _wait.Until(d => _driver.FindElements(FacebookElementsCoords.InstagramCheckBox)
                                        .FirstOrDefault());
            chkBox.Click();
        }

        private void AddTextContent()
        {
            IWebElement? textBox =
                _wait.Until(d => _driver.FindElements(FacebookElementsCoords.TextField)
                                        .FirstOrDefault());
            textBox.Clear();
            textBox.SendKeys(_formDto.Body);
        }

        private void AddImage()
        {
            IWebElement? image =
                _wait.Until(d => _driver.FindElements(FacebookElementsCoords.Image)
                                        .FirstOrDefault());
            image.Click();

            _winApi
                .Wait(200)
                .SendKeys(
                       VirtualKeyStates.VK_CONTROL,
                       VirtualKeyStates.L_key)
                .Wait(200)
                .SendText(_dialogHwnd, UploadedData.FolderPath)
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(200);

            For(5, () => _winApi
                              .SendKey(VirtualKeyStates.VK_TAB)
                              .Wait(100));
        }

        private void ClickSendBtn()
        {
            throw new NotImplementedException();
        }

        #endregion 
    }
}
