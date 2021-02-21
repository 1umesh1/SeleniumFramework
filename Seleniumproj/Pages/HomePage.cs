using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        public By btnNewCustomer = By.XPath("//a[contains(text(),'New Customer')]"); 
        public By btnEditCustomer = By.XPath("//a[contains(text(),'Edit Customer')]"); 
        public By btnSelenium = By.XPath("//body/div[1]/div[2]/nav[1]/div[1]/div[1]/ul[1]/li[1]/a[1]");
        
        






        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IList<IWebElement> SelectFromSeleniumOptions(  )
        {
            driver.FindElement(btnSelenium).Click();
            IList<IWebElement> ele = driver.FindElements(By.XPath("//body/div[1]/div[2]/nav[1]/div[1]/div[1]/ul[1]/li[1]/ul[1]/li/a"));
            foreach (IWebElement element in ele)
            { 
                Console.WriteLine(element +" " +element.Text);
            }
            return ele;

        }




        public void ValidateRadioButton()
        {
           
            var elements = SelectFromSeleniumOptions();
            //Click on radio & Checkbox option
            elements[1].Click(); 
            driver.FindElement(By.XPath("//div/input[ @value='Option 1']")).Click();
            var stat = driver.FindElement(By.XPath("//div[text() = 'Option1']")).GetAttribute("Checked");

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
