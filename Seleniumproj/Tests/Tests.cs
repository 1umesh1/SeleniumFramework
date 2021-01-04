using NUnit.Framework;
using System;
using System.Configuration;
using System.Threading;

namespace Seleniumproj
{
    public class Tests:BaseTest
    {
 



       [Test]
        public void VerifyLoginValidUserId_Password()
        {   
            HomePage.LogintoApp(credentials.username, credentials.password);
            string title = driver.Title;
            Console.WriteLine("title : " + title);
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Assert.AreEqual(title, "Guru99 Bank Manager HomePage"); 
        }


        [Test]
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
        [Test]
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
        [Test]
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

         






    }
}