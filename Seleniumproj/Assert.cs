using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Seleniumproj
{
    public class Assert:BaseTest
      
    { 
        public Assert(IWebDriver driver, ExtentReports _extent)
        {
            
        }

        public bool AssertionsFailed { get; private set; }

        private string Capture(IWebDriver driver, string screenShotName)
        {
            string location = AppDomain.CurrentDomain.BaseDirectory;
            location = location.Substring(0, location.IndexOf("\\bin")) + "\\Screenshot\\";


            try
            {
                Thread.Sleep(4000);
                location = location + screenShotName;
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(location, ScreenshotImageFormat.Png);

            }
            catch (Exception e)
            {
                throw (e);
            }
            return location;
        }


        private void TryAndLog(Action assertion, string message)
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
                        _test.Log(logstatus, "Test ended with " + logstatus+" :" + message);
                        _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

                        break;
                }
            }
            catch (Exception e)
            {
                Capture(driver, TestContext.CurrentContext.Test.Name);
                AssertionsFailed = true;
                throw (e);

            }



             
        }

        public void Fail(string message)
        {
            TryAndLog(() => NUnit.Framework.Assert.Fail(), message);
        }


        public void AreEqual(object expected, object actual, string message = "")
        {
            TryAndLog(() => NUnit.Framework.Assert.AreEqual(expected, actual), "Expected = '" + expected + "';Actual='" + actual + ";" + message);
        }

        public void AreNotEqual(object expected, object actual, string message = "")
        {
            TryAndLog(() => NUnit.Framework.Assert.AreNotEqual(expected, actual), "Expected = '" + expected + "';Actual='" + actual + ";" + message);
        }
        public void IsTrue(bool condition, string message)
        {
            TryAndLog(() => NUnit.Framework.Assert.IsTrue(condition), message);
        }
        public void IsFalse(bool condition, string message)
        {
            TryAndLog(() => NUnit.Framework.Assert.IsFalse(condition), message);
        }
        public void Pass(string message)
        {
            IsTrue(true, message);
        }
        public void NotNull(object anobject, string message)
        {
            TryAndLog(() => NUnit.Framework.Assert.NotNull(anobject), message);
        }

        public void Greater(int arg1, int arg2, string message)
        {
            TryAndLog(() => NUnit.Framework.Assert.Greater(arg1, arg2), message);
        }


    }
}
