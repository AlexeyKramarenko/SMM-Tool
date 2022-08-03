using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SMMTool.DTO;
using SMMTool.Utils.WindowsApi;

namespace SMMTool.Factories
{
    public interface IFacebookDependenciesFactory
    {

        WinApiWrapper CreateWinApiObject();
        FormDto CreateFormObject();
        IWebDriver CreateDriver();
        WebDriverWait CreateWebDriverWait();

    }
}