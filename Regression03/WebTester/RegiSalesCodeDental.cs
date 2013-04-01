using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Logger;
using DataVerification;

namespace WebTester
{
    public class RegiSalesCodeDental
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

   

         public void TheSalescode3Test(string salesCode)
        {
            driver = new FirefoxDriver();
            baseURL = "https://legacy.apexedi.com/";
            verificationErrors = new StringBuilder();

            
            SenderAPI logger = new SenderAPI();
            long TestID = logger.RegisterTest();
            //long TestID = 2;
            Retrieve verify = new Retrieve();

            var time = System.DateTime.Now;
            string full = Convert.ToString(time);
            string partial = full.Substring(15, 2);
            RandomStringGenerator random = new RandomStringGenerator();
            RandomStringGenerator random2 = new RandomStringGenerator();

            string name = random.GetRandom() + partial;
            string longName = random2.GetLongRandom() + partial;
            string userName = longName.Substring(4, 4) + name.Substring(2, 2) + longName.Substring(0, 4);

            string password = "Wx85mG3edV$ruI.wRRi?19knVu" + "Z9";

            try
            {
                driver.Navigate().GoToUrl(baseURL + "/");
                driver.FindElement(By.Id("gettingStarted")).Click();
                driver.FindElement(By.Id("p2"), 10).Click();
                driver.FindElement(By.Id("company")).Clear();
                driver.FindElement(By.Id("company")).SendKeys("TEST" + name + "TEST");
                driver.FindElement(By.Id("address1")).Clear();
                driver.FindElement(By.Id("address1")).SendKeys("211 S 1000 E");
                driver.FindElement(By.Id("city")).Clear();
                driver.FindElement(By.Id("city")).SendKeys("Provo");
                new SelectElement(driver.FindElement(By.Id("state"))).SelectByText("UT");
                driver.FindElement(By.Id("zip")).Clear();
                driver.FindElement(By.Id("zip")).SendKeys("84606");
                driver.FindElement(By.Id("contactName")).Clear();
                driver.FindElement(By.Id("contactName")).SendKeys(name);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(name + "d@babd.com");
                driver.FindElement(By.Id("phone")).Clear();
                driver.FindElement(By.Id("phone")).SendKeys("1234567890");
                new SelectElement(driver.FindElement(By.Id("groupSpecialty"))).SelectByText("Pediatric Dentistry - 1223P0221X");
                driver.FindElement(By.Id("taxID")).Clear();
                driver.FindElement(By.Id("taxID")).SendKeys("123456789");
                driver.FindElement(By.Id("npi")).Clear();
                driver.FindElement(By.Id("npi")).SendKeys("1234567893");
                driver.FindElement(By.Id("attachmentFacilityID")).Clear();
                driver.FindElement(By.Id("attachmentFacilityID")).SendKeys("aa1111");
                driver.FindElement(By.Id("softwareName")).Clear();
                driver.FindElement(By.Id("softwareName")).SendKeys("OneRingToRuleThemAll");
                driver.FindElement(By.Id("softwareVersion")).Clear();
                driver.FindElement(By.Id("softwareVersion")).SendKeys("1");
                driver.FindElement(By.Id("salesCode")).Clear();
                driver.FindElement(By.Id("salesCode")).SendKeys(salesCode);
                driver.FindElement(By.Id("provFirstName0")).Clear();
                driver.FindElement(By.Id("provFirstName0")).SendKeys(longName);
                driver.FindElement(By.Id("provMI0")).Clear();
                driver.FindElement(By.Id("provMI0")).SendKeys("T");
                driver.FindElement(By.Id("provLastName0")).Clear();
                driver.FindElement(By.Id("provLastName0")).SendKeys(name.Substring(3, 2) + longName.Substring(5, 3) + longName.Substring(1, 3));
                driver.FindElement(By.Id("wantsEligibility")).Click();
                driver.FindElement(By.Id("username")).Clear();
                driver.FindElement(By.Id("username")).SendKeys(userName);
                driver.FindElement(By.Id("password")).Clear();
                driver.FindElement(By.Id("password")).SendKeys(password);
                driver.FindElement(By.Id("confirmPassword")).Clear();
                driver.FindElement(By.Id("confirmPassword")).SendKeys(password);
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                driver.FindElement(By.Id("wantsBlockRate"), 10).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                new SelectElement(driver.FindElement(By.Id("renderingSpecialty0"), 10)).SelectByText("Dentist (I can do anything) - 122300000X");
                driver.FindElement(By.Id("renderingProvTaxID0")).Clear();
                driver.FindElement(By.Id("renderingProvTaxID0")).SendKeys("123456789");
                driver.FindElement(By.Id("npi0")).Clear();
                driver.FindElement(By.Id("npi0")).SendKeys("1234567893");
                driver.FindElement(By.Id("license0")).Clear();
                driver.FindElement(By.Id("license0")).SendKeys("552211");
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                driver.FindElement(By.Id("routingNumber0"), 10).Clear();
                driver.FindElement(By.Id("routingNumber0")).SendKeys("124001545");
                driver.FindElement(By.Id("bankAccountNumber0")).Clear();
                driver.FindElement(By.Id("bankAccountNumber0")).SendKeys("52615223");
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                driver.FindElement(By.Id("acceptTerms"), 10).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                driver.FindElement(By.CssSelector("a > img"), 10).Click();
            }
            catch (Exception ex)
            {
                logger.Warn(ex.Message, TestID);
            }
        try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());

            Verify verification = new Verify();
            bool results = verification.RegiVerifications(salesCode, userName, TestID);

            if (!results == true)
            {
                logger.Error("Failed Verifications", TestID);
            }

            logger.PassFailTest(results, TestID);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alert.Text;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
