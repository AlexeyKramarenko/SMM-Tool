using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SMMSender.Constants;
using SMMSender.DTO;
using SMMSender.Utils;
using SMMSender.Utils.WindowsApi;
using SMMSender.Utils.Extensions;
using static SMMSender.Utils.WindowsApi.WinApi;
using SMMSender.Factories;

namespace SMMSender.Processors.Implementations
{

    internal class FacebookProcessor : DesktopAppProcessorBase, IProcessor
    {

        private readonly IFacebookDependenciesFactory _factory;

        public FacebookProcessor(IFacebookDependenciesFactory factory)
        {
            _factory = factory;
        }

        public void Send()
        {
            var winApi = _factory.CreateWinApiObject();
            var formDto = _factory.CreateFormObject();
            var driver = _factory.CreateDriver();
            var wait = _factory.CreateWebDriverWait();

            IntPtr hwnd = InitHandler(WindowClass.OpenFileDialog);

            OpenPage(driver);
            CreateArticleClick(driver, wait);
            CheckInstagramCheckBox(driver, wait);
            AddTextContent(driver, wait, formDto);
            AddImage(driver, wait, winApi, hwnd);
            ClickSendBtn();
        }

        #region Private Methods

        private void OpenPage(
                        IWebDriver driver,
                        string url = "www.facebook.com/ic.misto/publishing_tools/") =>
            driver
                .Navigate()
                .GoToUrl(url);


        private void CreateArticleClick(IWebDriver driver, WebDriverWait wait)
        {
            IWebElement? btn =
                wait.Until(d => driver.FindElements(FacebookElementsCoords.ArticleBtn)
                                      .FirstOrDefault());
            btn.Click();
        }

        private void CheckInstagramCheckBox(IWebDriver driver, WebDriverWait wait)
        {
            IWebElement? chkBox =
                wait.Until(d => driver.FindElements(FacebookElementsCoords.InstagramCheckBox)
                                      .FirstOrDefault());
            chkBox.Click();
        }

        private void AddTextContent(IWebDriver driver, WebDriverWait wait, FormDto form)
        {
            IWebElement? textBox =
                wait.Until(d => driver.FindElements(FacebookElementsCoords.TextField)
                                      .FirstOrDefault());
            textBox.Clear();
            textBox.SendKeys(form.Body);
        }

        private void AddImage(
                        IWebDriver driver,
                        WebDriverWait wait,
                        WinApiWrapper winApi,
                        IntPtr hwnd)
        {
            IWebElement? image =
                wait.Until(d => driver.FindElements(FacebookElementsCoords.Image)
                                      .FirstOrDefault());
            image.Click();

            winApi
                .Wait(200)
                .SendKeys(
                       VirtualKeyStates.VK_CONTROL,
                       VirtualKeyStates.L_key)
                .Wait(200)
                .SendText(hwnd, UploadedData.FolderPath)
                .SendKey(VirtualKeyStates.VK_RETURN)
                .Wait(200);

            Enumerable
                .Range(0, 5)
                .ForEach(_ => winApi
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
