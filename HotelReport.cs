using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExtentReport
{
    public class HotelReport : BaseClass
    {
        public static ExtentReports exReports;
        public static ExtentTest exParent;
        public static ExtentTest exChild;
        public static ExtentHtmlReporter htmlRepoter;
        public static string path = "D:\\EducationalStuff\\AllCourses\\SQABootCamp\\Automation\\SeleniumExtentReport\\MyReport";
        public static void ProjectReport()
        {
            exReports = new ExtentReports();
            htmlRepoter = new ExtentHtmlReporter(path);
            htmlRepoter.Config.Theme = Theme.Standard;
            exReports.AttachReporter(htmlRepoter);

        }
      
}
    
}
