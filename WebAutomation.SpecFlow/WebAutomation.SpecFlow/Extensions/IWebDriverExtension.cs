using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;


namespace WebAutomation.SpecFlow.Extensions
{
    public static class IWebDriverExtension
    {
        /// <summary>
        /// Get the JavaScript Executor
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static IJavaScriptExecutor JavascriptExecutor(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }

        /// <summary>
        /// Executes the javascript required and returns the object type required
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="javascript"></param>
        /// <param name="args"></param>
        public static object ExecuteJavaScript(this IWebDriver driver, string javascript, params object[] args)
        {
            var jsDriver = driver.JavascriptExecutor();
            return jsDriver.ExecuteScript(javascript, args);
        }

        /// <summary>
        /// Executes Javascript scripts and returns the type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="driver"></param>
        /// <param name="javascript"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T ExecuteJavaScript<T>(this IWebDriver driver, string javascript, params object[] args)
        {
            var jsDriver = driver.JavascriptExecutor();
            return (T)jsDriver.ExecuteScript(javascript, args);
        }



        /// <summary>
        /// Find the element and ensure we use a wait automatically
        /// </summary>
        /// <param name="driver">The browser driver we are using</param>
        /// <param name="by">The query path to find the element</param>
        /// <param name="secondsWait">Override the seconds we want to wait, can not be less than the configured <c>Settings.Wait_XL</c></param>
        /// <returns></returns>
        public static IWebElement WaitNFindElement(this IWebDriver driver, By by, int secondsWait = 0)
        {
            WebDriverWait wait = driver.WaitDriver(secondsWait);
            return wait.Until(drv => drv.FindElement(by));
        }

        /// <summary>
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

        /// <summary>
        /// Determines if the element exists.
        /// </summary>
        /// <param name="driver">The browser driver that we are using</param>
        /// <param name="by">The element that you want to get</param>
        /// <param name="checkIsDisplayed">Do we need to perform a check on the display of the element</param>
        /// <returns>True if the element exits</returns>
        public static bool ElementExists(this IWebDriver driver, By by, bool checkIsDisplayed = true)
        {
            try
            {
                if (checkIsDisplayed)
                {
                    return driver.FindElement(by).Displayed;
                }
                else
                {
                    driver.FindElement(by);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines if the element exists.
        /// </summary>
        /// <param name="element">The base element to look from</param>
        /// <param name="driver">The browser driver that we are using</param>
        /// <param name="by">The element that you want to get</param>
        /// <param name="checkIsDisplayed">Do we need to perform a check on the display of the element</param>
        /// <returns>True if the element exits</returns>
        public static bool ElementExists(this IWebDriver driver, IWebElement element, By by, bool checkIsDisplayed = true)
        {
            if (element == null
                || by == null)
            {
                try
                {
                    if (checkIsDisplayed)
                    {
                        return element.FindElement(by).Displayed;
                    }
                    else
                    {
                        element.FindElement(by);
                    }

                    return true;
                }
                catch
                {
                    return false;
                }

            }

            return false;
        }

        /// <summary>
        /// Take the screenshot and get the file name
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="fullPage"></param>
        /// <returns></returns>
        

        /// <summary>
        /// Action a delay
        /// </summary>
        /// <param name="driver">The Web Driver</param>
        /// <param name="delay">The amount of delay we want to action, defaults to 300 milliseconds</param>
        public static void Delay(this IWebDriver driver, int delay = 300)
        {
            if (delay > 0)
            {
                System.Threading.Thread.Sleep(delay);
            }
        }
    }
}
