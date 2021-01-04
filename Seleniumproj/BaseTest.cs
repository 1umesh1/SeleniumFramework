using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using MimeKit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Seleniumproj.Pages;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace Seleniumproj
{
    public  class BaseTest
    {
        public static IWebDriver driver { get; set; }
        public   HomePage HomePage { get;   set; }
        public BasePage BasePage { get;   set; }
        public Assert Assert { get; set; }
        protected ExtentReports _extent;
        protected static ExtentTest _test;
        string dir = "";

        [SetUp]
        public void BeforeTest()
        {
            string location = AppDomain.CurrentDomain.BaseDirectory;
            location = location.Substring(0, location.IndexOf("\\bin"))  ;
            driver = new ChromeDriver(location);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(credentials.url);
             
            HomePage = new HomePage(driver );
            BasePage = new BasePage( );
            Assert = new Assert(driver, _extent);

            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            try
            {
                //To create report directory and add HTML report into it
                _extent = new ExtentReports();
                string location = AppDomain.CurrentDomain.BaseDirectory;
                location = location.Substring(0, location.IndexOf("\\bin")) +"\\Reports\\"  ;

                 dir = location  ;
                
                var htmlReporter = new ExtentHtmlReporter(dir +   "Automation_Report"  + ".html");
             
                _extent.AddSystemInfo("Environment", "Chrome");
                _extent.AddSystemInfo("User Name", "Umesh");
                _extent.AttachReporter(htmlReporter); 
                
            }
            catch (Exception e)
            {
                throw (e);
            }

            try
            {
               // driver = new ChromeDriver();
            }
            catch (Exception e)

            {
                throw (e);
            }
        }



        [TearDown]
        public void AfterTest()
        {
           
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        string screenShotPath = Capture(driver, TestContext.CurrentContext.Test.Name);
                        _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                           screenShotPath = Capture(driver, TestContext.CurrentContext.Test.Name);
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            driver.Close();
            driver.Quit();

        }
        private string Capture(IWebDriver driver, string screenShotName)
        {
            string location = AppDomain.CurrentDomain.BaseDirectory;
            location = location.Substring(0, location.IndexOf("\\bin")) + "\\Screenshot\\";

             
            try
            {
                Thread.Sleep(4000);
                location = location + screenShotName  ;
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(location, ScreenshotImageFormat.Png);
                  
            }
            catch (Exception e)
            {
                throw (e);
            }
            return location;
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            } 

            //To send Extent Report through Email
          //  SendReport_Email(); //uncomment needed
        }

        public void SendReport_Email()
        {
            var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json");
            var config = builder.Build();


            string location = AppDomain.CurrentDomain.BaseDirectory; 
            var html = location.Substring(0, location.IndexOf("\\bin")) + "\\Reports\\" + "index.html";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(config["Smtp:Username"], config["Smtp:Password"])
            };
             

            using (var message = new MailMessage(config["Smtp:Username"],"omeshumesh060@gmail.com")
            {
                Subject = "Automation Report",
                 
            })
            {
               var attachment = new System.Net.Mail.Attachment(html);
                message.Attachments.Add(attachment);  
               smtp.Send(  message);
            } 
            smtp.Dispose(); 
        }



      






    }
}
