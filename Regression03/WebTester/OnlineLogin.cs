using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Logger;
using Selenium;

namespace WebTester
{
    static class OnlineLogin
    {
        const string defaultLogin = "admin";
        const string defaultPassword = "hedge1!";
        const string baseURL = @"http:\\onetouch.apexedi.com";
        
        public static bool Login(this IWebDriver driver, Client client, long TestID)
        {
            driver.Navigate().GoToUrl(baseURL + "/secure/Login.aspx?redir=%2fsecure%2fDefault.aspx");
            driver.FindElement(By.Id("MainContent_tbUsername")).Clear();
            driver.FindElement(By.Id("MainContent_tbUsername")).SendKeys(client.ClientLogin);
            driver.FindElement(By.Id("MainContent_tbPassword")).Clear();
            driver.FindElement(By.Id("MainContent_tbPassword")).SendKeys(client.ClientPassword == null ? defaultPassword : client.ClientPassword);
            driver.FindElement(By.Id("MainContent_btnSubmit")).Click();
           

            if (driver.isElementPresent(By.Id("track_link"), 10))
            {
                return true;
            }
            
            driver.FindElement(By.Id("MainContent_tbUsername")).Clear();
            driver.FindElement(By.Id("MainContent_tbUsername")).SendKeys(defaultLogin + client.ClientID);
            driver.FindElement(By.Id("MainContent_tbPassword")).Clear();
            driver.FindElement(By.Id("MainContent_tbPassword")).SendKeys(defaultPassword);
            driver.FindElement(By.Id("MainContent_btnSubmit")).Click();
            if (driver.isElementPresent(By.Id("track_link"), 10))
            {
                return true;
            }
            return false;
        }

        public static bool Login(this IWebDriver driver, Client client)
        {
            long TestID = 55;
            return Login(driver, client, TestID);
        }


    }
}
