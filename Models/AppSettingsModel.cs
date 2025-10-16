using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brit_API_Automation.Models
{
    public class AppSettingsModel
    {
        public ApiSettings ApiSettings {  get; set; }
    }

    public class ApiSettings
    {
        public string BaseUrl { get; set; }
    }
}
