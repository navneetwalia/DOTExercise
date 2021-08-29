using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoTUITests
{
    class BasePageAction
    {
        protected IWebDriver driver;
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

    }
}
