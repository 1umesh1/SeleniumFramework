using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Seleniumproj.Pages
{
    public class HomePageSE1 : BaseTest
    {
        public By btnNoThanks = By.XPath("//a[contains(text(),'No, thanks!')]");
        //-------------Input Name---------------
        public By txtbxName = By.XPath("//input[@id='user-message']");
        public By btnShowMsg = By.XPath("//button[contains(text(),'Show Message')]");
        public By lblShowMsg = By.XPath("//span[@id='display']");

        //---------------Add Total----------------------------------

        public By txtbxSum1 = By.XPath("//input[@id='sum1']");
        public By txtbxSum2 = By.XPath("//input[@id='sum2']");
        public By btnSum = By.XPath("//button[contains(text(),'Get Total')]");
        public By lblSum = By.XPath("//span[@id='displayvalue']");

        //--------------------Input Forms------------------------
        public By lnkInputForms = By.XPath("//body/div[1]/div[2]/nav[1]/div[1]/div[2]/ul[1]/li[1]/a[1]");
        public By chkbxDemo = By.XPath("//input[@id='isAgeSelected']");
        public By lblChkbx = By.XPath("//div[@id='txtAge']");
        
        public By radioButtons = By.XPath("//div[2]/ul[1]/li[1]/ul[1]/li/a[text() = 'Radio Buttons Demo']");
        public By lblradiobtns = By.XPath("//div[contains(text(),'Radio Button Demo')]");
        public By rdmale = By.XPath("//div[2]/label[1]/input[1][@value ='Male']");
        public By rdfemale = By.XPath("//div[2]/label[2]/input[@value ='Female']");
        public By btncheck = By.XPath("//button[@id='buttoncheck']");
        public By lblrdselected = By.XPath("//body[1]/div[2]/div[1]/div[2]/div[1]/div[2]/p[3]");

        public HomePageSE1(IWebDriver driver)
        {
        }


        public void ClickNoThanks()
        {
            int a = 0;
            bool bstat = false;
            while (bstat == false || a == 10)
            {
                try
                { bstat = driver.FindElement(btnNoThanks).Displayed;

                }
                catch
                {

                }
                a++;

            }
            if (bstat == true)
                driver.FindElement(btnNoThanks).Click();

        }
        public HomePageSE1 LaunchSeleniumWebpage()
        {
            //driver.Navigate().GoToUrl(credentials.url2);

            ClickNoThanks();
            string title = driver.FindElement(By.XPath("//body/div[1]/div[1]/div[1]/div[2]/div[1]/a[1]")).Text;
            Assert.AreEqual(title, "Selenium Easy");

            return this;
        }

        public HomePageSE1 EnterName(string name)
        {
            driver.FindElement(txtbxName).SendKeys(name);
            driver.FindElement(btnShowMsg).Click();
            string Name1 = driver.FindElement(lblShowMsg).Text;
            Assert.AreEqual(name, Name1);
            return this;
        }
        public HomePageSE1 ProvideTwoNumber(int a, int b)
        {
            driver.FindElement(txtbxSum1).SendKeys(a.ToString());
            driver.FindElement(txtbxSum2).SendKeys(b.ToString());
            driver.FindElement(btnSum).Click();

            string sum = driver.FindElement(lblSum).Text;
            Assert.AreEqual((a + b).ToString(), sum, "Verify Equal");
            Console.WriteLine("Sum of " + a + " & " + b + "= " + sum);
            return this;
        }

        public void ClickInputForms()
        {
            driver.FindElement(lnkInputForms).Click();
        }

        public HomePageSE1 SelectInputFormsOption(int a)
        {
            ClickInputForms();
            string xpath = " //body/div[1]/div[2]/nav[1]/div[1]/div[2]/ul[1]/li[1]/ul[1]/li[" + a + "]/a[1]";
            driver.FindElement(By.XPath(xpath)).Click();
            return this;
        }

        public HomePageSE1 ClickCheckbx()
            {
            driver.FindElement(chkbxDemo).Click();
            string txtChkbx = driver.FindElement(lblChkbx).Text;
            Assert.AreEqual(txtChkbx, "Success - Check box is checked");

            return this;
            }



        public HomePageSE1 ClickRadioButton()
        {
            driver.FindElement(radioButtons).Click();
            string txtrd = driver.FindElement(lblradiobtns).Text;
            Assert.AreEqual(txtrd, "Radio Buttons Demo"); 
            return this;
        }

        public HomePageSE1 SelectMaleRadio()
        { 
            Thread.Sleep(1000);
            driver.FindElement(rdmale).Click();
            driver.FindElement(btncheck).Click();
            string text = driver.FindElement(lblrdselected).Text;
            Assert.AreEqual(text, "Radio button 'Male' is checked");
            return this;
        }


        public HomePageSE1 SelectFemaleRadio()
        { 
            driver.FindElement(rdfemale).Click();
            driver.FindElement(btncheck).Click();
            string text = driver.FindElement(lblrdselected).Text;
            Assert.AreEqual(text, "Radio button 'Female' is checked");
            return this;
        }




    }
}
