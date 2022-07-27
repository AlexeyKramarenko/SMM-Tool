using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SMMSender.DTO;
using SMMSender.Utils.WindowsApi;

namespace SMMSender.Factories
{
    public interface IFacebookDependenciesFactory
    {

        WinApiWrapper CreateWinApiObject();
        FormDto CreateFormObject();
        IWebDriver CreateDriver();
        WebDriverWait CreateWebDriverWait();

    }
}