using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SMMTool.Factories.Implementations
{
    public class FacebookDependenciesFactory : ProcessorDependenciesFactory, IFacebookDependenciesFactory
    {

        public IWebDriver CreateDriver()
        {
            var driver = new ChromeDriver();

            driver
              .Manage()
              .Timeouts()
              .ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }

        public WebDriverWait CreateWebDriverWait() =>
            new WebDriverWait(CreateDriver(), TimeSpan.FromSeconds(15));

    }
}
