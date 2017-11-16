using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AdvertAutomation.SiteParsers
{
    public class ThreeNine
    {
        private static string Name = "999.md";
        private static string MainUrl = "https://999.md/";
        private string Lang { get; set; }
        private static string MainNavigation_class = "main-CatalogNavigation";
        private static string TopBarFrame_id = "topbar-panel";
        private static string PoopUpTopBarFrame_id = "topbar-popup";
        private static string LoginBtn_id = "user-login-btn";
        private static string InputUsername_name = "login";
        private static string InputPassword_name = "password";
        private static string LoginBtnPoopUp_class = "popup-login-form-footer-submit";

        public enum Languages
        {
            RO,
            RU
        }

        public ThreeNine(Languages lg)
        {
            if (lg == Languages.RO)
                Lang = "ro/";
            else if (lg == Languages.RU)
                Lang = "ru/";
        }

        public bool LogIn(string username, string password)
        {
            IWebDriver driver = BrowserDriver._driver;
            driver.Url = MainUrl;
            try
            {
                var topPanelFrame = driver.FindElement(By.Id(TopBarFrame_id));

                driver.SwitchTo().Frame(topPanelFrame);
                var loginBtn = driver.FindElement(By.Id(LoginBtn_id));
                if (loginBtn != null && loginBtn.Displayed)
                {
                    loginBtn.Click();
                }

                driver.SwitchTo().DefaultContent();
                var loginFrame = driver.FindElement(By.Id(PoopUpTopBarFrame_id));
                driver.SwitchTo().Frame(loginFrame);
                var loginInput = driver.FindElement(By.Name(InputUsername_name));
                var passInput = driver.FindElement(By.Name(InputPassword_name));
                var logintBtn2 = driver.FindElement(By.ClassName(LoginBtnPoopUp_class));
                if (loginInput.Displayed && passInput.Displayed && logintBtn2.Displayed)
                {
                    loginInput.SendKeys(username);
                    passInput.SendKeys(password);
                    logintBtn2.Click();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\n-------------------------------------------");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------------------");
                return false;
            }
            return true;
        }

        public bool LogOut()
        {
            return true;
        }

        public bool Register()
        {
            return true;
        }

        public List<string> GetCategory()
        {
            IWebDriver driver = BrowserDriver._driver;
            driver.Url = MainUrl + Lang;
            List<string> category = new List<string>();

            IList<IWebElement> catElem = driver.FindElement(By.ClassName(MainNavigation_class)).FindElements(By.TagName("a"));
            foreach (var el in catElem)
            {
                if (el.Displayed)
                    category.Add(el.Text);
            }
            return category;
        }
    }
}
