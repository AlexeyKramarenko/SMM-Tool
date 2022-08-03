using OpenQA.Selenium;

namespace SMMTool.Constants
{
    public class FacebookElementsCoords
    {
        public static By ArticleBtn => By.XPath("/html/body/div[1]/div[1]/div[1]/div/span/div/div[2]/div[3]/div/div[1]/div[2]/div/span/div/div/div[2]");
        public static By InstagramCheckBox => By.XPath("/html/body/div[4]/div[2]/div/div/div/div/div/div/div[2]/div/div[1]/div/div/div/div/div[1]/div[1]/div[2]/div[2]/div/div/label/div/div/div[1]/div[1]/div/div[1]/input");
        public static By TextField => By.XPath("/html/body/div[4]/div[2]/div/div/div/div/div/div/div[2]/div/div[1]/div/div/div/div/div[2]/div[2]/div/div/div/div[1]/div[2]/div/div/div[1]/div/div/div/div/div/div/div");
        public static By Image => By.XPath("/html/body/div[4]/div[2]/div/div/div/div/div/div/div[2]/div/div[1]/div/div/div/div/div[5]/div[1]/div/a/span/div/div/div[2]");
    }
}
