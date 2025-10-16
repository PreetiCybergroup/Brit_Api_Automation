using Brit_API_Automation.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Brit_API_Automation.Helpers
{
    public static class ObjectDataHelper
    {
        public static ObjectDataModel ReadDataFromJsonFile(string fileName)
        {
            string jsonData = File.ReadAllText(Path.Combine("TestData", fileName));
            var data = JsonConvert.DeserializeObject<ObjectDataModel>(jsonData);
            if (data == null)
            {
                ReportManager.LogFail($"Deserialization returned null for file: {fileName}");
                throw new InvalidDataException("Invalid JSON structure.");
            }
            return data;
        }
    }
}
