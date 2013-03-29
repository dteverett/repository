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
    
    public class WebTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        static SenderAPI logger = new SenderAPI();
        RandomStringGenerator random = new RandomStringGenerator();

        public void TheRegistrationTest()
        {
            SenderAPI logger = new SenderAPI();

            long TestID = logger.RegisterTest();

            driver = new FirefoxDriver();
            baseURL = "https://legacy.apexedi.com/";
            verificationErrors = new StringBuilder();

            var time = System.DateTime.Now;
            string full = Convert.ToString(time);
            string partial = full.Substring(15, 2);
            
            string name = random.GetRandom() + partial;

            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("gettingStarted")).Click();
            driver.FindElement(By.Id("company")).Clear();
            driver.FindElement(By.Id("company")).SendKeys("AwesomeO");
            driver.FindElement(By.Id("p1")).Click();
            driver.FindElement(By.Id("address1")).Clear();
            driver.FindElement(By.Id("address1")).SendKeys("111 S 999 E");
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("Orem");
            new SelectElement(driver.FindElement(By.Id("state"))).SelectByText("UT");
            driver.FindElement(By.Id("zip")).Clear();
            driver.FindElement(By.Id("zip")).SendKeys("84057");
            driver.FindElement(By.Id("contactName")).Clear();
            driver.FindElement(By.Id("contactName")).SendKeys("Darian Everett");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("deverett@apexedi.com");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("8011239999");
            new SelectElement(driver.FindElement(By.Id("groupSpecialty"))).SelectByText("Anesthesiology - Addiction Medicine - 207LA0401X");
            driver.FindElement(By.Id("taxID")).Clear();
            driver.FindElement(By.Id("taxID")).SendKeys("123456789");
            driver.FindElement(By.Id("npi")).Clear();
            driver.FindElement(By.Id("npi")).SendKeys("1234567893");
            driver.FindElement(By.Id("attachmentFacilityID")).Clear();
            driver.FindElement(By.Id("attachmentFacilityID")).SendKeys("AA99" + partial);
            driver.FindElement(By.Id("softwareName")).Clear();
            driver.FindElement(By.Id("softwareName")).SendKeys("Sun");
            driver.FindElement(By.Id("softwareVersion")).Clear();
            driver.FindElement(By.Id("softwareVersion")).SendKeys("6.3.4");
            driver.FindElement(By.Id("provFirstName0")).Clear();
            driver.FindElement(By.Id("provFirstName0")).SendKeys("Darian");
            driver.FindElement(By.Id("provLastName0")).Clear();
            driver.FindElement(By.Id("provLastName0")).SendKeys("Everett");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(name);
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("Password1");
            driver.FindElement(By.Id("confirmPassword")).Clear();
            driver.FindElement(By.Id("confirmPassword")).SendKeys("Password1");

            try
            {
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]"), 10).Click();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message, 2, TestID);
            }
            new SelectElement(driver.FindElement(By.Id("renderingSpecialty0"))).SelectByText("Anesthesiology - Addiction Medicine - 207LA0401X");
            driver.FindElement(By.Id("renderingProvTaxID0")).Clear();
            driver.FindElement(By.Id("renderingProvTaxID0")).SendKeys("123456789");
            driver.FindElement(By.Id("npi0")).Clear();
            driver.FindElement(By.Id("npi0")).SendKeys("1234567893");
            driver.FindElement(By.Id("license0")).Clear();
            driver.FindElement(By.Id("license0")).SendKeys("4567893");
            try
            {
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message, 2, TestID);
            }
            driver.FindElement(By.Id("routingNumber0")).Clear();
            driver.FindElement(By.Id("routingNumber0")).SendKeys("124000054");
            driver.FindElement(By.Id("bankAccountNumber0")).Clear();
            driver.FindElement(By.Id("bankAccountNumber0")).SendKeys("32251625");
            try
            {
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();


                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
                driver.FindElement(By.Id("acceptTerms")).Click();
                driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
                driver.FindElement(By.CssSelector("a > img")).Click();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message, 2, TestID);
            }

            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            //Assert.AreEqual("", verificationErrors.ToString());
        }


         private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                logger.Error(ex.Message);
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
