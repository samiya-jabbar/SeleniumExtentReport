using System;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumExtentReport;

namespace SeleniumExtentReport
{
    [TestClass]
    public class ExecutionClass : HotelReport
    {
        #region ObjectInitialization
        LoginClass loginClass = new LoginClass();
       // SearchPage searchPage = new SearchPage();
        #endregion       

        #region TestContext
        public TestContext instance;
        public TestContext TestContext
        {
            get { return instance; }
            set { instance = value; }
        }
        #endregion

        #region AssemblyInitializationAndCleanUp
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext TestContext)
        {
            ProjectReport();
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            exReports.Flush();
        }
        #endregion

        #region ClassInitializationAndCleanUp
        #endregion

        #region TestInitializationAndCleanUp
        [TestInitialize]
        public void TestInit()
        {
            exParent = exReports.CreateTest(TestContext.TestName);
            DriverInit();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DriverCLose();
        }
        #endregion

        #region LoginTestCases

        [TestMethod]
        [TestCategory("LoginPage"), TestCategory("LoginwithValid")]
        [Owner("SamiyaJabbar")]
        [Description("This task case checks the login with valid user name and password")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Xml_LoginWIthValidUserPass", DataAccessMethod.Sequential)]
        public void Xml_LoginWIthValidUserPass()
        {
            exChild = exParent.CreateNode("LoginWithValid");
            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            loginClass.LoginWithValid(url, user, pass);
        }

        [TestMethod]
        [TestCategory("LoginPage"), TestCategory("LoginwithInalid")]
        [Owner("SamiyaJabbar")]
        [Description("This task case checks the login with valid user name but invalid password")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Xml_LoginWIthInValidUserPass", DataAccessMethod.Sequential)]
        public void Xml_LoginWIthInValidUserPass()
        {
            exChild = exParent.CreateNode("LoginWithInvalid");
            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            loginClass.LoginWithInValid(url, user, pass);
        }

        #endregion
    }
}