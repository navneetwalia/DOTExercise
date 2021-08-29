namespace WebAutomation.SpecFlow.Browser
{
    /// <summary>
    /// Base Browser which is used on all driver types
    /// </summary>
    public class BrowserBase
    {

        /// <summary>
        /// Gets or sets a value indicating whether the browser should accept self-signed SSL certificates.
        /// </summary>
        public bool? AcceptInsecureCertificates { get; set; }
    }
}
