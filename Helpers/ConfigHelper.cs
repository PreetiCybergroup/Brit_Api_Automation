using Brit_API_Automation.Models;
using Microsoft.Extensions.Configuration;

namespace Brit_API_Automation.Helpers
{
    /// <summary>
    /// Provides access to application configuration settings loaded from appsettings.json.
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// Holds the deserialized configuration settings from appsettings.json.
        /// </summary>
        public static AppSettingsModel AppSettings { get; set; }

        /// <summary>
        /// Static constructor that loads and binds configuration from appsettings.json.
        /// </summary>
        static ConfigHelper()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Bind JSON to model
            AppSettings = new AppSettingsModel();
            configuration.Bind(AppSettings);
        }

        /// <summary>
        /// Retrieves the base URL for API requests from the configuration.
        /// </summary>
        /// <returns>The base URL string.</returns>
        public static string GetBaseUrl()
        {
            return AppSettings.ApiSettings.BaseUrl;
        }
    }
}
