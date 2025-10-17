namespace Brit_API_Automation.Models
{
    /// <summary>
    /// Represents the root configuration model for application settings.
    /// Maps to the structure of appsettings.json.
    /// </summary>
    public class AppSettingsModel
    {
        /// <summary>
        /// Contains API-specific configuration settings.
        /// </summary>
        public ApiSettings ApiSettings { get; set; }
    }

    /// <summary>
    /// Represents API-related configuration values.
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// The base URL of the API used for test execution.
        /// </summary>
        public string BaseUrl { get; set; }
    }
}
