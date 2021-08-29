using Microsoft.Extensions.Configuration;


namespace WebAutomation.Configuration
{
    public class Context
    {
        public static Context Current = new Context();

        /// <summary>
        /// Loads the configuration file
        /// </summary>
        /// <param name="jsonFile">Override the json file to process</param>
        public Context(string jsonFile = "appsettings.json")
        {


            // set the configuration builder
            IConfigurationBuilder config = new ConfigurationBuilder();
                               
                //.SetBasePath(System.IO.Directory.GetCurrentDirectory())
                //                .AddJsonFile(jsonFile, optional: true, reloadOnChange: true)
                //                .AddJsonFile($"appsettings.{System.Environment.MachineName}.json", true, true)
                //                .AddEnvironmentVariables();

           

            //Build the configuration
            Configuration = config.Build();
        }

        public IConfiguration Configuration { get; private set; }
    }
}
