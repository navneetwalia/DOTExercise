using System.Collections.Generic;

namespace WebAutomation.SpecFlow.Browser
{
    public class Chrome
    {

        // Adds arguments to be appended to the Chrome.exe command line.
        public List<string> Arguments { get; set; }

        // Adds a list of base64-encoded strings representing Chrome extensions to the list of extensions to be installed in the instance of Chrome.
        public List<string> EncodedExtensions { get; set; }


        // Adds arguments to be excluded from the list of arguments passed by default to the Chrome.exe command line by chromedriver.exe.
        public List<string> ExcludedArguments { get; set; }

        // Adds a list of paths to packed Chrome extensions (.crx files) to be installed in the instance of Chrome.
        public List<string> Extensions { get; set; }

        // Gets or sets a value indicating whether Chrome should be left running after the ChromeDriver instance is exited. Defaults to false.
        public bool? LeaveBrowserRunning { get; set; }

        // Gets or sets the location of the Chrome browser's binary executable file.
        public string BinaryLocation { get; set; }


    }
}
