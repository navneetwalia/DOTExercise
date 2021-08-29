using WebAutomation.SpecFlow.Drivers;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using System;

namespace WebAutomation.SpecFlow.Hooks
{
    [Binding]
    public sealed class BrowserDriver
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ConfigurationDriver _configurationDriver;
        private IWebDriver _driver;
        private readonly string _workingDirectory;
       

        public BrowserDriver(ScenarioContext scenarioContext, ConfigurationDriver configurationDriver)
        {
            _configurationDriver = configurationDriver;
            _scenarioContext = scenarioContext;
            _workingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "");
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
            var browser = string.Empty;
            foreach (var tag in _scenarioContext.ScenarioInfo.Tags)
            {
                var tokens = tag.Split(':');
                if (tokens.Length == 2 && tokens[0] == "Browser")
                {
                    browser = tokens[1];
                    break;
                }
            }
            //_scenarioContext.TryGetValue("Browser", out var browser);

            switch (browser)
            {
                case "Chrome":
                    _driver = SetupChromeDriver();
                    break;
                case "Firefox":
                    _driver =  SetupFirefoxDriver();
                    break;
                case "Edge":
                    _driver = SetupEdgeDriver();
                    break;
                default: throw new NotSupportedException("Browser not supported <null>");
            };
            _scenarioContext.ScenarioContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }


        [AfterScenario(Order = 2)]
        public void CleanUp()
        {
            try
            {
                _driver.Close();
                _driver.Quit();
                _driver.Dispose();

            }
            catch (System.NotImplementedException nie)
            {
                System.Diagnostics.Trace.WriteLine("Driver already closed or has quit: " + nie.Message);
            }
            catch (System.InvalidOperationException ioe)
            {
                System.Diagnostics.Trace.WriteLine("Driver already closed or has quit: " + ioe.Message);
            }
            catch (WebDriverException wex)
            {
                System.Diagnostics.Trace.WriteLine("Driver already closed or has quit: " + wex.Message);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Driver already closed or has quit: " + ex.Message);
            }
            finally
            {
                System.Diagnostics.Trace.WriteLine("Driver Object Closed");
            }

        }

        [AfterStep(Order = 2)]
        public void CleanUpFailedStep()
        {
            if (_scenarioContext.TestError != null)
            {
                CleanUp();
            }

        }


        /// Setup the firefox driver
       
        private IWebDriver SetupFirefoxDriver()
        {
            var service = FirefoxDriverService.CreateDefaultService(_workingDirectory);
            return new FirefoxDriver(service);
        }

        
        /// Setup the chrome driver
        
        private IWebDriver SetupChromeDriver()
        {
            // setup the chrome options
            ChromeOptions options = new ChromeOptions();

            // we get our configuration for chrome from the appsettings.json file or machine based file
            var chromeBuilder = _configurationDriver.Browser.Chrome;

            // do we have any arguments for the driver
            if (chromeBuilder?.Arguments != null && chromeBuilder.Arguments.Count > 0)
            {
                // add the arguments
                options.AddArguments(chromeBuilder.Arguments);
            }

#if !DEBUG
            // we for headless mode in any other mode then debug
            options.AddArgument("headless");        // force headless in non debug mode
#endif

           
            // do we need to include anything to be excluded
            if (chromeBuilder?.ExcludedArguments != null && chromeBuilder.ExcludedArguments.Count > 0)
            {
                // add the arguments
                options.AddExcludedArguments(chromeBuilder.ExcludedArguments);
            }

            if (chromeBuilder?.Extensions != null && chromeBuilder.Extensions.Count > 0)
            {
                // add the arguments
                options.AddExtensions(chromeBuilder.Extensions);
            }

           
            if (chromeBuilder.LeaveBrowserRunning.HasValue)
            {
                options.LeaveBrowserRunning = chromeBuilder.LeaveBrowserRunning.Value;
            }

            options.SetLoggingPreference(LogType.Browser, LogLevel.All);

            return new ChromeDriver(_workingDirectory, options);
        }

       // Setup the Edge Driver
     
        private IWebDriver SetupEdgeDriver()
        {
            EdgeOptions edgeOptions = new EdgeOptions { UseChromium = false };

            return new EdgeDriver(_workingDirectory, edgeOptions);
        }

    }
}
