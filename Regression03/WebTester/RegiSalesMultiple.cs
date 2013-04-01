using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class RegiSalesMultiple
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        SenderAPI logger;


        public void MultipleProvidersTest(string salesCode)
        {
            driver = new FirefoxDriver();
            baseURL = "https://legacy.apexedi.com/";
            verificationErrors = new StringBuilder();
            Random random = new Random();
            int decision = random.Next();
            RandomStringGenerator rString = new RandomStringGenerator();
            string comName = rString.GetLongRandom();

            driver.Navigate().GoToUrl(baseURL + "/index.jsp");
            driver.FindElement(By.Id("gettingStarted"), 10).Click();
            driver.FindElement(By.Id("company"), 10).Clear();
            driver.FindElement(By.Id("company")).SendKeys(comName);

            if (decision % 2 == 0)
            {
                TheMedicalMultipleTest(salesCode);
            }
            else
            {
                TheDentalMultipleTest(salesCode);
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

        }


        private void TheMedicalMultipleTest(string salesCode)
        {
            logger = new SenderAPI();
            long TestID = logger.RegisterTest();
            //long TestID = 2;

            var time = System.DateTime.Now;
            string full = Convert.ToString(time);
            string partial = full.Substring(15, 2);
            RandomStringGenerator random = new RandomStringGenerator();
            RandomStringGenerator random2 = new RandomStringGenerator();
            RandomStringGenerator random3 = new RandomStringGenerator();
            RandomStringGenerator random4 = new RandomStringGenerator();
            RandomStringGenerator random5 = new RandomStringGenerator();

            string name = random.GetRandom() + partial;
            string longName = random2.GetLongRandom() + partial;
            string name1 = random3.GetLongRandom();
            string name2 = random4.GetLongRandom();
            string name3 = random5.GetLongRandom();

            string password = "a9Z10GTrvn6XLpi8h4vH";
            string userName = name1.Substring(5, 4) + name2.Substring(2, 3) + name3.Substring(4, 2) + longName.Substring(7, 1);

            try
            {
                driver.FindElement(By.Id("p1")).Click();
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
                driver.FindElement(By.Id("email")).SendKeys(name + "@ymail.com");
                driver.FindElement(By.Id("phone")).Clear();
                driver.FindElement(By.Id("phone")).SendKeys("8014275556");
                new SelectElement(driver.FindElement(By.Id("groupSpecialty"))).SelectByText("Adult Companion - 372600000X");
                driver.FindElement(By.Id("taxID")).Clear();
                driver.FindElement(By.Id("taxID")).SendKeys("123456789");
                driver.FindElement(By.Id("npi")).Clear();
                driver.FindElement(By.Id("npi")).SendKeys("1234567893");
                driver.FindElement(By.Id("attachmentFacilityID")).Clear();
                driver.FindElement(By.Id("attachmentFacilityID")).SendKeys("ju7789");
                driver.FindElement(By.Id("softwareName")).Clear();
                driver.FindElement(By.Id("softwareName")).SendKeys("Capti Filli");
                driver.FindElement(By.Id("softwareVersion")).Clear();
                driver.FindElement(By.Id("softwareVersion")).SendKeys("3.4");
                driver.FindElement(By.Id("salesCode")).Clear();
                driver.FindElement(By.Id("salesCode")).SendKeys("MMM1615");
                driver.FindElement(By.Id("numberProviders")).Clear();
                driver.FindElement(By.Id("numberProviders")).SendKeys("3");
                driver.FindElement(By.Id("provFirstName0")).Clear();
                driver.FindElement(By.Id("provFirstName0")).SendKeys(name1.Substring(4, 5));
                driver.FindElement(By.Id("provLastName0")).Clear();
                driver.FindElement(By.Id("provLastName0"), 10).SendKeys(name2.Substring(0, 4));
                driver.FindElement(By.Id("provFirstName1"), 15).Clear();
                driver.FindElement(By.Id("provFirstName1")).SendKeys(name1.Substring(0, 3));
                driver.FindElement(By.Id("provLastName1")).Clear();
                driver.FindElement(By.Id("provLastName1")).SendKeys(name3.Substring(4, 5));
                driver.FindElement(By.Id("provFirstName2")).Clear();
                driver.FindElement(By.Id("provFirstName2")).SendKeys(name3.Substring(0, 4));
                driver.FindElement(By.Id("provLastName2")).Clear();
                driver.FindElement(By.Id("provLastName2")).SendKeys(name2);
                driver.FindElement(By.Id("wantsElectStatements")).Click();
                driver.FindElement(By.Id("wantsElectPayment")).Click();
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
                new SelectElement(driver.FindElement(By.Id("renderingSpecialty0"), 10)).SelectByText("Adult Companion - 372600000X");
                driver.FindElement(By.Id("renderingProvTaxID0")).Clear();
                driver.FindElement(By.Id("renderingProvTaxID0")).SendKeys("123456789");
                driver.FindElement(By.Id("npi0")).Clear();
                driver.FindElement(By.Id("npi0")).SendKeys("1234567893");
                driver.FindElement(By.Id("license0")).Clear();
                driver.FindElement(By.Id("license0")).SendKeys("bm6996");
                new SelectElement(driver.FindElement(By.Id("renderingSpecialty1"))).SelectByText("Anesthesiology - 207L00000X");
                driver.FindElement(By.Id("renderingProvTaxID1")).Clear();
                driver.FindElement(By.Id("renderingProvTaxID1")).SendKeys("123456789");
                driver.FindElement(By.Id("npi1")).Clear();
                driver.FindElement(By.Id("npi1")).SendKeys("1234567893");
                driver.FindElement(By.Id("license1")).Clear();
                driver.FindElement(By.Id("license1")).SendKeys("fu3874");
                new SelectElement(driver.FindElement(By.Id("renderingSpecialty2"))).SelectByText("Anaplastologist - 229N00000X");
                driver.FindElement(By.Id("renderingProvTaxID2")).Clear();
                driver.FindElement(By.Id("renderingProvTaxID2")).SendKeys("123456789");
                driver.FindElement(By.Id("npi2")).Clear();
                driver.FindElement(By.Id("npi2")).SendKeys("1234567893");
                driver.FindElement(By.Id("license2")).Clear();
                driver.FindElement(By.Id("license2")).SendKeys("nm2252");
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                driver.FindElement(By.Id("stat_CreditCardsAccepted_1"), 10).Click();
                driver.FindElement(By.Id("stat_CreditCardsAccepted_0")).Click();
                driver.FindElement(By.Id("stat_CreditCardsAccepted_3")).Click();
                driver.FindElement(By.Id("stat_CreditCardsAccepted_2")).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
                driver.FindElement(By.Id("routingNumber0"), 10).Clear();
                driver.FindElement(By.Id("routingNumber0")).SendKeys("124001545");
                driver.FindElement(By.Id("bankAccountNumber0")).Clear();
                driver.FindElement(By.Id("bankAccountNumber0")).SendKeys("698574123");
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                driver.FindElement(By.Id("acceptTerms"), 10).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
                driver.FindElement(By.CssSelector("a > img"), 10).Click();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }


            Verify verify = new Verify();
            bool results = verify.RegiVerifications(salesCode, userName, TestID);

            if (!results == true)
            {
                logger.Warn("Failed verifications for test", TestID);
            }

            logger.PassFailTest(results, TestID);
        }


 
         private void TheDentalMultipleTest(string salesCode)
         {
            logger = new SenderAPI();
            long TestID = logger.RegisterTest();
            //long TestID = 2;

            var time = System.DateTime.Now;
            string full = Convert.ToString(time);
            string partial = full.Substring(15, 2);
            RandomStringGenerator random = new RandomStringGenerator();
            RandomStringGenerator random2 = new RandomStringGenerator();
            RandomStringGenerator random3 = new RandomStringGenerator();
            RandomStringGenerator random4 = new RandomStringGenerator();
            RandomStringGenerator random5 = new RandomStringGenerator();

            string name = random.GetRandom() + partial;
            string NameName = random2.GetLongRandom() + partial;
            string name1 = random3.GetLongRandom();
            string name2 = random4.GetLongRandom();
            string name3 = random5.GetLongRandom();

            string password = "a9Z10GTrvn6XLpi8h4vH";
            string userName = name1.Substring(5, 4) + name2.Substring(2, 3) + name3.Substring(4, 2) + NameName.Substring(7, 1);

            int steps = 0;

            try
            {
                driver.FindElement(By.Id("p2")).Click();
                driver.FindElement(By.Id("address1")).Clear();
                driver.FindElement(By.Id("address1")).SendKeys("211 S 1000 E");
                driver.FindElement(By.Id("city")).Clear();
                driver.FindElement(By.Id("city")).SendKeys("Provo");
                new SelectElement(driver.FindElement(By.Id("state"))).SelectByText("UT");
                driver.FindElement(By.Id("zip")).Clear();
                driver.FindElement(By.Id("zip")).SendKeys("84606");
                driver.FindElement(By.Id("contactName")).Clear();
                driver.FindElement(By.Id("contactName")).SendKeys(NameName);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(NameName + "@FMAIL.com");
                driver.FindElement(By.Id("phone")).Clear();
                driver.FindElement(By.Id("phone")).SendKeys("99988887777");
                new SelectElement(driver.FindElement(By.Id("groupSpecialty"))).SelectByText("Anesthesiology - 207L00000X");
                driver.FindElement(By.Id("taxID")).Clear();
                driver.FindElement(By.Id("taxID")).SendKeys("123456789");
                driver.FindElement(By.Id("npi")).Clear();
                driver.FindElement(By.Id("npi")).SendKeys("1234567893");
                driver.FindElement(By.Id("attachmentFacilityID")).Clear();
                driver.FindElement(By.Id("attachmentFacilityID")).SendKeys("ff6666");
                driver.FindElement(By.Id("softwareName")).Clear();
                driver.FindElement(By.Id("softwareName")).SendKeys("FireStorm");
                driver.FindElement(By.Id("softwareVersion")).Clear();
                driver.FindElement(By.Id("softwareVersion")).SendKeys("2.3.2");
                driver.FindElement(By.Id("salesCode")).Clear();
                driver.FindElement(By.Id("salesCode")).SendKeys("MMM1615");
                driver.FindElement(By.Id("numberProviders")).Clear();
                driver.FindElement(By.Id("numberProviders")).SendKeys("3");
                driver.FindElement(By.Id("provFirstName0")).Clear();
                driver.FindElement(By.Id("provFirstName0")).SendKeys(name1.Substring(4, 5));
                driver.FindElement(By.Id("provLastName0")).Clear();
                driver.FindElement(By.Id("provLastName0")).SendKeys(name2.Substring(0, 4));
                driver.FindElement(By.Id("provFirstName1")).Clear();
                driver.FindElement(By.Id("provFirstName1")).SendKeys(name1.Substring(0, 3));
                driver.FindElement(By.Id("provLastName1")).Clear();
                driver.FindElement(By.Id("provLastName1")).SendKeys(name3.Substring(4, 5));
                driver.FindElement(By.Id("provFirstName2")).Clear();
                driver.FindElement(By.Id("provFirstName2")).SendKeys(name3.Substring(0, 4));
                driver.FindElement(By.Id("provLastName2")).Clear();
                driver.FindElement(By.Id("provLastName2")).SendKeys(name2);
                driver.FindElement(By.Id("wantsElectStatements")).Click();
                driver.FindElement(By.Id("wantsElectPayment")).Click();
                driver.FindElement(By.Id("wantsEligibility")).Click();
                driver.FindElement(By.Id("username")).Clear();
                driver.FindElement(By.Id("username")).SendKeys(userName);
                driver.FindElement(By.Id("password")).Clear();
                driver.FindElement(By.Id("password")).SendKeys(password);
                driver.FindElement(By.Id("confirmPassword")).Clear();
                driver.FindElement(By.Id("confirmPassword")).SendKeys(password);
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
                steps++;
                driver.FindElement(By.Id("wantsBlockRate"), 10).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
                steps++;
                new SelectElement(driver.FindElement(By.Id("renderingSpecialty0"), 10)).SelectByText("Anesthesiology - 207L00000X");
                driver.FindElement(By.Id("renderingProvTaxID0")).Clear();
                driver.FindElement(By.Id("renderingProvTaxID0")).SendKeys("123456789");
                driver.FindElement(By.Id("npi0")).Clear();
                driver.FindElement(By.Id("npi0")).SendKeys("1234567893");
                driver.FindElement(By.Id("license0")).Clear();
                driver.FindElement(By.Id("license0")).SendKeys("ff3333");
                new SelectElement(driver.FindElement(By.Id("renderingSpecialty1"))).SelectByText("Anesthesiology - 207L00000X");
                driver.FindElement(By.Id("renderingProvTaxID1")).Clear();
                driver.FindElement(By.Id("renderingProvTaxID1")).SendKeys("123456789");
                driver.FindElement(By.Id("npi1")).Clear();
                driver.FindElement(By.Id("npi1")).SendKeys("1234567893");
                driver.FindElement(By.Id("license1")).Clear();
                driver.FindElement(By.Id("license1")).SendKeys("gg5555");
                new SelectElement(driver.FindElement(By.Id("renderingSpecialty2"))).SelectByText("Clinic/Center - Ambulatory Surgical - 261QA1903X");
                driver.FindElement(By.Id("renderingProvTaxID2")).Clear();
                driver.FindElement(By.Id("renderingProvTaxID2")).SendKeys("123456789");
                driver.FindElement(By.Id("npi2")).Clear();
                driver.FindElement(By.Id("npi2")).SendKeys("1234567893");
                driver.FindElement(By.Id("license2")).Clear();
                driver.FindElement(By.Id("license2")).SendKeys("bf6789");
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                steps++;
                driver.FindElement(By.Id("stat_CreditCardsAccepted_1"), 10).Click();
                driver.FindElement(By.Id("stat_CreditCardsAccepted_0")).Click();
                driver.FindElement(By.Id("stat_CreditCardsAccepted_3")).Click();
                driver.FindElement(By.Id("stat_CreditCardsAccepted_2")).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
                driver.FindElement(By.Id("routingNumber0"), 10).Clear();
                driver.FindElement(By.Id("routingNumber0")).SendKeys("124001545");
                driver.FindElement(By.Id("bankAccountNumber0")).Clear();
                driver.FindElement(By.Id("bankAccountNumber0")).SendKeys("96874321");
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
                steps++;
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                steps++;
                driver.FindElement(By.Id("acceptTerms"), 10).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
                steps++;
                driver.FindElement(By.CssSelector("a > img"), 10).Click();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, TestID);
            }

            if (steps < 6)
            {
                logger.Fatal("Unable to complete the registration process: Finished " + steps + " pages", TestID);
                logger.PassFailTest(false, TestID, "Didn't complete process: " + steps + " pages were completed out of 6");
                return;
            }
            Verify verify = new Verify();
            bool results = verify.RegiVerifications(salesCode, userName, TestID);

            if (!results == true)
            {
                logger.Warn("Failed verifications for test", TestID);
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
