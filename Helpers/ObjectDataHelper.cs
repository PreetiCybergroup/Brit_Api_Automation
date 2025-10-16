using Brit_API_Automation.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brit_API_Automation.Helpers
{
    public static class ObjectDataHelper
    {
        public static ObjectDataModel ReadDataFromJsonFile(string fileName)
        {
            string jsonData = File.ReadAllText($"TestData\\{fileName}");
            return JsonConvert.DeserializeObject<ObjectDataModel>(jsonData);
        }
    }
}
