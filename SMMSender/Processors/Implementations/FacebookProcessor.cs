using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SMMSender.Constants;
using SMMSender.DTO;
using SMMSender.Utils;
using SMMSender.Utils.WindowsApi;
using SMMSender.Utils.Extensions;
using static SMMSender.Utils.WindowsApi.WinApi;
using SMMSender.Factories;
using SMMSender.Utils.Optional;
using SMMSender.Processors.Implementations.FacebookDTO;

namespace SMMSender.Processors.Implementations
{
    internal partial class FacebookProcessor : DesktopAppProcessorBase, IProcessor
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

            OpenPage(driver, "www.facebook.com/***/publishing_tools/");

            IResult result =
                CreateArticleClick(driver, wait)
                    .Map(_ => CheckInstagramCheckBox(driver, wait)
                        .Map(_ => AddTextContent(driver, wait, formDto)
                            .Map(_ => AddImage(driver, wait, winApi, hwnd)
                                .Map(ok => (IResult)ok)
                                .Reduce(err => err))
                            .Reduce(err => err))
                        .Reduce(err => err))
                    .Reduce(err => err);
        }

        #region Private Methods

        private void OpenPage(IWebDriver driver, string url) =>
            driver.Navigate().GoToUrl(url);

        private Either<NotFound, Ok> CreateArticleClick(
                                                IWebDriver driver,
                                                WebDriverWait wait)
        {
            IWebElement btn =
                wait.Until(d => driver.FindElements(FacebookElementsCoords.ArticleBtn)
                    .FirstOrNone())
                    .Map(btn => btn)
                    .Reduce(() => new NoWebElement());

            btn.Click();

            return (btn is NoWebElement)
                ? new NotFound("Article button is not found.")
                : new Ok();
        }

        private Either<NotFound, Ok> CheckInstagramCheckBox(
                                                IWebDriver driver,
                                                WebDriverWait wait)
        {
            IWebElement chkBox =
                wait.Until(d => driver.FindElements(FacebookElementsCoords.InstagramCheckBox)
                    .FirstOrNone())
                    .Map(btn => btn)
                    .Reduce(() => new NoWebElement());

            chkBox.Click();

            return (chkBox is NoWebElement)
                ? new NotFound("Checkbox is not found.")
                : new Ok();
        }

        private Either<NotFound, Ok> AddTextContent(
                                            IWebDriver driver,
                                            WebDriverWait wait,
                                            FormDto form)
        {
            IWebElement textBox =
                wait.Until(d => driver.FindElements(FacebookElementsCoords.TextField)
                    .FirstOrNone())
                    .Map(txt => txt)
                    .Reduce(() => new NoWebElement());

            textBox.Clear();
            textBox.SendKeys(form.Body);

            return (textBox is NoWebElement)
                ? new NotFound("TextBox is not found.")
                : new Ok();
        }

        private Either<NotFound, Ok> AddImage(
                                        IWebDriver driver,
                                        WebDriverWait wait,
                                        WinApiWrapper winApi,
                                        IntPtr hwnd)
        {
            IWebElement image =
                wait.Until(d => driver.FindElements(FacebookElementsCoords.Image)
                    .FirstOrNone())
                    .Map(img => img)
                    .Reduce(() => new NoWebElement());

            if (image is NoWebElement)
            {
                return new NotFound("Image button is not found.");
            }

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

            return new Ok();
        }

        #endregion 

    }
}
