using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;

namespace AdvertAutomation
{
    public class BrowserDriver
    {
        private static string _driverPath = @"..\..\..\BootWPF\Drivers";
        public static IWebDriver _driver;

        public static IWebDriver InitDriver(string name)
        {
            if (name == "chrome")
                _driver = new ChromeDriver(_driverPath);
            else
                _driver = new PhantomJSDriver(_driverPath);
            return _driver;
        }

        public static IWebDriver InitDriver ()
        {
            _driver = new PhantomJSDriver(_driverPath);
            return _driver;
        }
    }
}
