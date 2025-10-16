using Brit_API_Automation.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brit_API_Automation.Helpers
{
    public static class ConfigHelper
    {
        public static AppSettingsModel AppSettings { get; set; }

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

        public static string GetBaseUrl()
        {
            return AppSettings.ApiSettings.BaseUrl;
        }
    }
}
