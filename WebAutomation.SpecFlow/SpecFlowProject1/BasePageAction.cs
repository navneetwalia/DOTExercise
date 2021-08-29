using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebAutomation.SpecFlow.Extensions;
using SeleniumExtras.WaitHelpers;

namespace DOTExercise
{
    class BasePageAction
    {
        protected IWebDriver driver;

        public BasePageAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected int timeout = 20;
        public BasePageAction VerifyPageUrl(string pageUrl)
        {

            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<bool>((d) =>
            {
                driver.Manage().Window.Maximize();
                string page = d.Url;
                return d.Url.Contains(pageUrl);
            });
            return this;
        }

        public BasePageAction VerifyPageTitle(string pageTitle)
        {
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<bool>((d) =>
            {
                driver.Manage().Window.Maximize();
                return d.Title.Contains(pageTitle);
            });
            return this;

        }

        public BasePageAction VerifyPageContent(string content)
        {
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<bool>((d) =>
            {
                return d.PageSource.Contains(content);
            });
            return this;
        }

        public BasePageAction Verify(string pageUrl, string pageTitle, string pageContent)
        {
            VerifyPageUrl(pageUrl);
            VerifyPageTitle(pageTitle);
            VerifyPageContent(pageContent);
            return this;
        }

        public BasePageAction Click(By element)
        {
            driver.FindElement(element).Click();
            IWebDriverExtension.Delay(driver, 600);
            return this;
        }

        public BasePageAction EnterText(By element, string textValue)
        {
            driver.FindElement(element).SendKeys(textValue);
            IWebDriverExtension.Delay(driver, 500);
            return this;
        }

        public IWebElement WaitUntilElementIsVisible(By element)
        {
            return driver.WaitDriver().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        public BasePageAction SelectElementById(string selectId, string optionText)
        {
            driver.FindElement(By.XPath("//select[@id='" + selectId + "']/option[contains(.,'" + optionText + "')]")).Click();
            return this;

        }

        public BasePageAction SelectElementByIndex(string selectId, int index=0)
        {
            var selectElement = new SelectElement(driver.FindElement(By.Id(selectId)));
            selectElement.SelectByIndex(index);
            return this;

        }
        

    }
}
