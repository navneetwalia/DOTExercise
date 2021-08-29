using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;


namespace WebAutomation.SpecFlow.Extensions
{
    public static class IWebDriverExtension
    {
         
        /// Get the wait driver out with the set defined seconds.
        /// This is used to help with extra features such as expected conditions but also ignores key exceptions
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="secondsWait">Override the amount of seconds to wait</param>
        /// <param name="sleepInterval">Change the sleep interval in milliseconds, if zero it will use default</param>
        /// <returns></returns>
        /// <example>
        ///     driver.WaitDriver().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath))).Click();
        /// </example>
        public static WebDriverWait WaitDriver(this IWebDriver driver, int secondsWait = 0, double sleepInterval = 0)
        {
            // if not supplied use our default
            if (secondsWait <= 0)
            {
                secondsWait = 30;//Settings.Wait_XL;
            }

            // set the main driver
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsWait));

            // do we want to change the polling interval
            if (sleepInterval > 0)
            {
                webDriverWait.PollingInterval = TimeSpan.FromMilliseconds(sleepInterval);
            }

            // make sure we ignore the types that throw errors
            webDriverWait.IgnoreExceptionTypes(typeof(TargetInvocationException), typeof(NoSuchElementException), typeof(InvalidOperationException));

            return webDriverWait;
        }

                       
        // Action a delay
        // <param name="driver">The Web Driver</param>
        // <param name="delay">The amount of delay we want to action, defaults to 300 milliseconds</param>
        public static void Delay(this IWebDriver driver, int delay = 300)
        {
            if (delay > 0)
            {
                System.Threading.Thread.Sleep(delay);
            }
        }
    }
}
