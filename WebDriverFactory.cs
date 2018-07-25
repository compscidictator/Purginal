using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Purginal
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver()
        {
            return new FirefoxDriver(FirefoxDriverService.CreateDefaultService(BinDir));
        }
        
        private static string BinDir => Path.GetDirectoryName(typeof(WebDriverFactory).Assembly.Location);
    }
}
