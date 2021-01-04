using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seleniumproj.Pages
{
    public   class HomePage: BaseTest

    { 
        public By userid = By.XPath("//*[@name='uid']");
        public By password = By.XPath("//*[@name='password']");
        public By btnlogin = By.XPath("//*[@name='btnLogin']");
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LogintoApp(string username, string passw)
        {
            var a = driver.FindElement(userid);
            driver.FindElement(userid).SendKeys(username);
            driver.FindElement(password).SendKeys(passw);
            driver.FindElement(btnlogin).Click();

        }
        

    }
}
