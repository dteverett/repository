using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;


namespace WebTester
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                try
                {
                    return wait.Until(drv => drv.FindElement(by));
                }
                catch (Exception ex)
                {
                    try
                    {
                        return wait.Until(drv => drv.FindElement(by));
                    }
                    catch (Exception exc)
                    {
                        //TODO
                        //Add logging
                    }

                }
            }
            return driver.FindElement(by);
        }

        //public static IWebElement FindElement(this IWebDriver driver, By by)
        //{
        //    return FindElement(driver, by, 10);
        //}

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }

        public static bool isElementPresent(this IWebDriver driver, By by)
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

        public static bool isElementPresent(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds <= 0)
                timeoutInSeconds = 5;
                try
                {
                    driver.FindElement(by, timeoutInSeconds);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
        }
    }
}