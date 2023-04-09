using System;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumExtentReport
{
    public class BaseClass
    {
        public static IWebDriver driver;
        public static string path;
        public static void DriverInit()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
           / options.AddArgument("Incognito");
            driver = new ChromeDriver(options);

        }
        public static void DriverCLose()
        {

            driver.Close();
        }
        public static void OpenUrl(string link)
        {
            try
            {
                driver.Url = link;
                TakeScreenshot(driver, Status.Pass, "Open url");
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Open Url Failed " + ex);
            }
        }
        public static void Assertion(By locator, string expectedText)
        {
            string actualText = driver.FindElement(locator).Text;
            Assert.AreEqual(expectedText, actualText);
        }
        public static void Write(By locator, string value)
        {

            try
            {
                driver.FindElement(locator).SendKeys(value);
                TakeScreenshot(driver, Status.Pass, "Enter " + locator);
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Enter Failed" + ex);
            }
        }
        public static void Click(By locator)
        {

            try
            {
                driver.FindElement(locator).Click();
                TakeScreenshot(driver, Status.Pass, "Click on " + locator);
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Click Failed " + ex);
            }
        }
        public static void TakeScreenshot(IWebDriver driver, Status status, string stepDetail)
        {
            //// Add Full directory (Absolute) if you want to attached screenshots
            //string path = @"..\..\..\Screenshots\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            //Screenshot image_username = ((ITakesScreenshot)driver).GetScreenshot();
            //image_username.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            //ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
            //    .CreateScreenCaptureFromPath(path + ".png").Build());


            // No need to save Screnshots on Folder
            byte[] imageArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            HotelReport.exChild.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromBase64String(base64ImageRepresentation, "data:image/png;base64,").Build());

        }
    }
}