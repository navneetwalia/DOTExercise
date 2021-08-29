namespace WebAutomation.SpecFlow.Browser
{
    // Defines the Browsers Configuration, as each browser has different settings and configurations
      public class Browser
    {
       
        public const string BrowserSection = "Browser";

        public Chrome Chrome { get; set; } = new Chrome();

        public Firefox Firefox { get; set; } = new Firefox();

    }
}
