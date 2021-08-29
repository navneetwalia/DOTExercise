using Microsoft.Extensions.Configuration;

namespace WebAutomation.SpecFlow.Drivers
{
    /// <summary>
    /// Configuration Driver used for SpecFlow and Selenium
    /// </summary>
    public class ConfigurationDriver
    {
        /// <summary>
        /// The Selenium Base URL
        /// </summary>
        private const string SeleniumBaseUrlConfigFieldName = "seleniumBaseUrl";

        /// <summary>
        /// The configuration, which will be loaded with lazy mode
        /// </summary>
        private readonly IConfiguration _configuration;

        private Browser.Browser _browser;

        /// <summary>
        /// Constructor for the configuration driver
        /// </summary>
        public ConfigurationDriver()
        {
            // get the configuration
           _configuration = WebAutomation.Configuration.Context.Current.Configuration;

            // we need to set the browser so we can cast to it
            Browser.Browser browser = new Browser.Browser();

            // set the browser config
            _configuration.GetSection("Browser").Bind(browser);
            _browser = browser;
        }

        /// <summary>
        /// Exposed Configuraiton for end points
        /// </summary>
       public IConfiguration Configuration => _configuration;

        /// <summary>
        /// The Browser data from the configuration
        /// </summary>
        public Browser.Browser Browser => _browser;

        /// <summary>
        /// The exposed Selenium Base Url
        /// </summary>
        public string SeleniumBaseUrl => Configuration[SeleniumBaseUrlConfigFieldName];

    }
  
}