using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;

namespace Seleniumproj
{
    public class Tests:BaseTest
    {
 



       //[Test]
        public void VerifyLoginValidUserId_Password()
        {   
            HomePage.LogintoApp(credentials.username, credentials.password);
            string title = driver.Title;
            Console.WriteLine("title : " + title);
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Assert.AreEqual(title, "Guru99 Bank Manager HomePage"); 
        }


       // [Test]
        public void VerifyLogin_InvalidUserId_ValidPassword()
        {
            HomePage.LogintoApp(11+credentials.username, credentials.password);
         
            Thread.Sleep(TimeSpan.FromSeconds(10));
           // Assert.AreEqual(title, "Guru99 Bank Manager HomePage");

            var alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            alert.Accept();
            Assert.AreEqual(alertText, "User or Password is not valid");
            

        }
        // [Test]
        public void VerifyLogin_ValidUserId_InValidPassword()
        {
            HomePage.LogintoApp(credentials.username, 11+credentials.password);

            Thread.Sleep(TimeSpan.FromSeconds(10));
            // Assert.AreEqual(title, "Guru99 Bank Manager HomePage");

            var alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            alert.Accept();
            Assert.AreEqual(alertText, "User or Password is not valid");
            

        }
        // [Test]
        public void VerifyLogin_InvalidUserId_InValidPassword()
        {
            HomePage.LogintoApp(11+credentials.username, 11 + credentials.password);

            Thread.Sleep(TimeSpan.FromSeconds(10));
            // Assert.AreEqual(title, "Guru99 Bank Manager HomePage");

            var alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            alert.Accept();
            Assert.AreEqual(alertText, "User or Password is not valid");
            
            Console.WriteLine("Hello World!");
        
        }

      //  [Test]
        public void ClickonSeleniumOption_RadioCheckbox()
        {
            HomePage.LogintoApp(credentials.username,  credentials.password);

            Thread.Sleep(TimeSpan.FromSeconds(10));
            // Assert.AreEqual(title, "Guru99 Bank Manager HomePage"); 
       
            HomePage.ValidateRadioButton();



        }


        [Test]
        public void VerifySeleniumEasy_Web()
        {
            HomePageSE1.
            LaunchSeleniumWebpage(); 
        }

        [Test]
        public void VerifyName()
        {
            HomePageSE1.
            LaunchSeleniumWebpage().EnterName("Test"); 
        }

        [Test]
        public void VerifyAddition()
        {
            int a = 100; int b = 200;
            HomePageSE1.LaunchSeleniumWebpage().ProvideTwoNumber(a, b);
        }
        
              [Test]
        public void VerifyCheckbox()
        {
            int a = 2;
            HomePageSE1.LaunchSeleniumWebpage().SelectInputFormsOption(a).ClickCheckbx();
        }


        [Test]
        public void VerifyMaleRadioButton()
        {
            int a = 3;
            HomePageSE1.LaunchSeleniumWebpage().SelectInputFormsOption(a).SelectMaleRadio();
        }

        [Test]
        public void VerifyFemaleRadioButton()
        {
            int a = 3;
            HomePageSE1.LaunchSeleniumWebpage().SelectInputFormsOption(a).SelectFemaleRadio();
        }



    }
}