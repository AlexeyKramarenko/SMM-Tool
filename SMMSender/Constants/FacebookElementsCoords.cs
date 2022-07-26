using OpenQA.Selenium;

namespace SMMSender.Constants
{
    public class FacebookElementsCoords
    {
        public static By ArticleBtn { get; } = By.XPath("/html/body/div[1]/div[1]/div[1]/div/span/div/div[2]/div[3]/div/div[1]/div[2]/div/span/div/div/div[2]");
        public static By InstagramCheckBox { get; } = By.XPath("/html/body/div[4]/div[2]/div/div/div/div/div/div/div[2]/div/div[1]/div/div/div/div/div[1]/div[1]/div[2]/div[2]/div/div/label/div/div/div[1]/div[1]/div/div[1]/input");
        public static By TextField { get; } = By.XPath("/html/body/div[4]/div[2]/div/div/div/div/div/div/div[2]/div/div[1]/div/div/div/div/div[2]/div[2]/div/div/div/div[1]/div[2]/div/div/div[1]/div/div/div/div/div/div/div");
        public static By Image { get; } = By.XPath("/html/body/div[4]/div[2]/div/div/div/div/div/div/div[2]/div/div[1]/div/div/div/div/div[5]/div[1]/div/a/span/div/div/div[2]");
    }
}
