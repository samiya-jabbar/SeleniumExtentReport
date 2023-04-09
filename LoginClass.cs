using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumExtentReport
{
    public class LoginClass : BaseClass
    {
        #region Locators

        By userLoc = By.Id("username");
        By passLoc = By.Id("password");
        By loginLoc = By.Id("login");
        By assertValidLoc = By.CssSelector("body > table.content > tbody > tr:nth-child(1) > td:nth-child(1)");
        string assertValidExpected = "Welcome to Adactin Group of Hotels";
        By assertInvalidLoc = By.ClassName("auth_error");
        string assertInvalidExpected = "Invalid Login details or Your Password might have expired. Click here to reset your password";

        #endregion


        public void LoginWithValid(string url, string username, string password)
        {

            OpenUrl(url);
            Write(userLoc, username);
            Write(passLoc, password);
            Click(loginLoc);
            Assertion(assertValidLoc, assertValidExpected);
        }


        public void LoginWithInValid(string url, string username, string password)
        {
            OpenUrl(url);
            Write(userLoc, username);
            Write(passLoc, password);
            Click(loginLoc);
            Assertion(assertInvalidLoc, assertInvalidExpected);
        }
    }
}