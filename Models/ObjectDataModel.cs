using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brit_API_Automation.Model
{
    public class ObjectDataModel
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public Data? data { get; set; }


        
    }
    public class Data
    {
        public int? year { get; set; }
        public float? price { get; set; }
        public string? cpuModel { get; set; }
        public string? hardDiskSize { get; set; }
    }
}
