using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Logger;

namespace WebTester
{
    
    public class RegiSalesCode
    {
        SenderAPI logger = new SenderAPI();
        

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;


        public void TheSalesCodeTest(string salesCode)
        {
             

            SenderAPI logger = new SenderAPI();
            //long TestID = logger.RegisterTest();
            long TestID = 2;

            var time = System.DateTime.Now;
            string full = Convert.ToString(time);
            string partial = full.Substring(15, 2);
            RandomStringGenerator random = new RandomStringGenerator();
            RandomStringGenerator random2 = new RandomStringGenerator();
            
            string name = random.GetRandom() + partial;
            string longName = random2.GetLongRandom() + partial;

             driver = new FirefoxDriver();
            baseURL = "https://legacy.apexedi.com/";
            verificationErrors = new StringBuilder();

            try
            {
                driver.Navigate().GoToUrl(baseURL + "/");
                driver.FindElement(By.Id("gettingStarted")).Click();
                driver.FindElement(By.Id("company"), 10).Clear();
                driver.FindElement(By.Id("company")).SendKeys("TEST" + longName + "TEST");
                driver.FindElement(By.Id("p1")).Click();
                driver.FindElement(By.Id("address1")).Clear();
                driver.FindElement(By.Id("address1")).SendKeys("174 S 1100 E");
                driver.FindElement(By.Id("city")).Clear();
                driver.FindElement(By.Id("city")).SendKeys("American Fork");
                new SelectElement(driver.FindElement(By.Id("state"))).SelectByText("UT");
                driver.FindElement(By.Id("zip")).Clear();
                driver.FindElement(By.Id("zip")).SendKeys("84003");
                driver.FindElement(By.Id("contactName")).Clear();
                driver.FindElement(By.Id("contactName")).SendKeys(longName);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(longName + "@cloudchat.com");
                driver.FindElement(By.Id("phone")).Clear();
                driver.FindElement(By.Id("phone")).SendKeys("3333333333");
                new SelectElement(driver.FindElement(By.Id("groupSpecialty"))).SelectByText("Agencies - Public Health or Welfare - 251K00000X");
                driver.FindElement(By.Id("taxID")).Clear();
                driver.FindElement(By.Id("taxID")).SendKeys("123456789");
                driver.FindElement(By.Id("npi")).Clear();
                driver.FindElement(By.Id("npi")).SendKeys("1234567893");
                driver.FindElement(By.Id("attachmentFacilityID")).Clear();
                driver.FindElement(By.Id("attachmentFacilityID")).SendKeys("JC3333");
                driver.FindElement(By.Id("softwareName")).Clear();
                driver.FindElement(By.Id("softwareName")).SendKeys("Holiness");
                driver.FindElement(By.Id("softwareVersion")).Clear();
                driver.FindElement(By.Id("softwareVersion")).SendKeys("1");
                driver.FindElement(By.Id("salesCode")).Clear();
                driver.FindElement(By.Id("salesCode")).SendKeys(salesCode);
                driver.FindElement(By.Id("provFirstName0")).Clear();
                driver.FindElement(By.Id("provFirstName0")).SendKeys(longName);
                driver.FindElement(By.Id("provMI0")).Clear();
                driver.FindElement(By.Id("provMI0")).SendKeys("B");
                driver.FindElement(By.Id("provLastName0")).Clear();
                driver.FindElement(By.Id("provLastName0")).SendKeys(name);

                driver.FindElement(By.Id("wantsEligibility")).Click();

                driver.FindElement(By.Id("username")).Clear();
                driver.FindElement(By.Id("username")).SendKeys(name);
                driver.FindElement(By.Id("password")).Clear();
                driver.FindElement(By.Id("password")).SendKeys("Password1");
                driver.FindElement(By.Id("confirmPassword")).Clear();
                driver.FindElement(By.Id("confirmPassword")).SendKeys("Password1");

                //logger.Info("Test Connection", TestID);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message, TestID);
            }
            try
            {
                new SelectElement(driver.FindElement(By.Id("renderingSpecialty0"))).SelectByText("Agencies - Public Health or Welfare - 251K00000X");
                driver.FindElement(By.Id("renderingProvTaxID0")).Clear();
                driver.FindElement(By.Id("renderingProvTaxID0")).SendKeys("123456789");
                driver.FindElement(By.Id("npi0")).Clear();
                driver.FindElement(By.Id("npi0")).SendKeys("1234567893");
                driver.FindElement(By.Id("license0")).Clear();
                driver.FindElement(By.Id("license0")).SendKeys("A345");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 15).Click();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("routingNumber0"), 5).Clear();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            try
            {
                driver.FindElement(By.Id("routingNumber0")).SendKeys("124001545");
            
            driver.FindElement(By.Id("bankAccountNumber0")).Clear();
            driver.FindElement(By.Id("bankAccountNumber0")).SendKeys("32251635");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }
            try
            {
            driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
            driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message, TestID);
            }
            try
            {
                driver.FindElement(By.Id("acceptTerms")).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }

            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            try
            {
                Assert.AreEqual("", verificationErrors.ToString());

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }


            
            

            



        }

        public void TheSalesCodeTest()
        {
            string salesCode = "APXXZ3092";
            SenderAPI logger = new SenderAPI();

            long TestExecutionCode = logger.RegisterTest();

            var time = System.DateTime.Now;
            string full = Convert.ToString(time);
            string partial = full.Substring(15, 2);
            RandomStringGenerator random = new RandomStringGenerator();

            string name = random.GetRandom() + partial;
            string longName = random.GetLongRandom() + partial;

            driver = new FirefoxDriver();
            baseURL = "https://legacy.apexedi.com/";
            verificationErrors = new StringBuilder();

            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("gettingStarted")).Click();
            driver.FindElement(By.Id("company"), 10).Clear();
            driver.FindElement(By.Id("company")).SendKeys("TestTester");
            driver.FindElement(By.Id("p1")).Click();
            driver.FindElement(By.Id("address1")).Clear();
            driver.FindElement(By.Id("address1")).SendKeys("174 S 1100 E");
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("American Fork");
            new SelectElement(driver.FindElement(By.Id("state"))).SelectByText("UT");
            driver.FindElement(By.Id("zip")).Clear();
            driver.FindElement(By.Id("zip")).SendKeys("84003");
            driver.FindElement(By.Id("contactName")).Clear();
            driver.FindElement(By.Id("contactName")).SendKeys(longName);
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("JC@cloudchat.com");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("3333333333");
            new SelectElement(driver.FindElement(By.Id("groupSpecialty"))).SelectByText("Agencies - Public Health or Welfare - 251K00000X");
            driver.FindElement(By.Id("taxID")).Clear();
            driver.FindElement(By.Id("taxID")).SendKeys("123456789");
            driver.FindElement(By.Id("npi")).Clear();
            driver.FindElement(By.Id("npi")).SendKeys("1234567893");
            driver.FindElement(By.Id("attachmentFacilityID")).Clear();
            driver.FindElement(By.Id("attachmentFacilityID")).SendKeys("JC3333");
            driver.FindElement(By.Id("softwareName")).Clear();
            driver.FindElement(By.Id("softwareName")).SendKeys("Holiness");
            driver.FindElement(By.Id("softwareVersion")).Clear();
            driver.FindElement(By.Id("softwareVersion")).SendKeys("1");
            driver.FindElement(By.Id("salesCode")).Clear();
            driver.FindElement(By.Id("salesCode")).SendKeys(salesCode);
            driver.FindElement(By.Id("provFirstName0")).Clear();
            driver.FindElement(By.Id("provFirstName0")).SendKeys(longName);
            driver.FindElement(By.Id("provMI0")).Clear();
            driver.FindElement(By.Id("provMI0")).SendKeys("B");
            driver.FindElement(By.Id("provLastName0")).Clear();
            driver.FindElement(By.Id("provLastName0")).SendKeys("Toses");

            driver.FindElement(By.Id("wantsEligibility")).Click();

            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(name);
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("Password1");
            driver.FindElement(By.Id("confirmPassword")).Clear();
            driver.FindElement(By.Id("confirmPassword")).SendKeys("Password1");
            driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
            driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
            new SelectElement(driver.FindElement(By.Id("renderingSpecialty0"))).SelectByText("Agencies - Public Health or Welfare - 251K00000X");
            driver.FindElement(By.Id("renderingProvTaxID0")).Clear();
            driver.FindElement(By.Id("renderingProvTaxID0")).SendKeys("123456789");
            driver.FindElement(By.Id("npi0")).Clear();
            driver.FindElement(By.Id("npi0")).SendKeys("1234567893");
            driver.FindElement(By.Id("license0")).Clear();
            driver.FindElement(By.Id("license0")).SendKeys("A345");
            driver.FindElement(By.CssSelector("input[type=\"image\"]"), 15).Click();
            try
            {
                driver.FindElement(By.Id("routingNumber0"), 5).Clear();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            driver.FindElement(By.Id("routingNumber0")).SendKeys("124001545");

            driver.FindElement(By.Id("bankAccountNumber0")).Clear();
            driver.FindElement(By.Id("bankAccountNumber0")).SendKeys("32251635");
            driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
            driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
            driver.FindElement(By.Id("acceptTerms")).Click();
            driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();

            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
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
