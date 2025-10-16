using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brit_API_Automation.Helpers
{
    public static class RestRequestExtensions
    {
        /// <summary>
        /// Adds a JSON body to the request while ignoring null values.
        /// Useful for PATCH requests where partial updates are needed.
        /// </summary>
        public static RestRequest AddJsonBodyIgnoreNulls<T>(this RestRequest request, T body)
        {
            // Serialize object to JSON ignoring nulls
            string json = JsonConvert.SerializeObject(body, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            // Add serialized JSON as request body
            request.AddStringBody(json, DataFormat.Json);
            return request;
        }
    }
}
