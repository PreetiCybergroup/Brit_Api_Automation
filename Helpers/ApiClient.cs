using Brit_API_Automation.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brit_API_Automation.Helpers
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public RestResponse ExecuteRequest(RestRequest _request)
        {
            return _client.Execute(_request); 
        }

        public async Task<RestResponse> ExecuteRequestAsync(RestRequest _request)
        {
            return await _client.ExecuteAsync(_request);
        }

        public RestRequest CreateRequest(string? resource, Method method)
        {
            //RestRequest request;
            //if(!String.IsNullOrWhiteSpace(resource))
            //{
               var request = new RestRequest(resource, method);
            //}
            
            request.AddHeader("Content-Type", "application/json");
            return request;
        }


        public string CreateObject(ObjectDataModel body)
        {
            var request = CreateRequest("objects", Method.Post);
            request.AddJsonBody(body);
            var response = ExecuteRequest(request);
            return JObject.Parse(response.Content)["id"].ToString();
        }

        public RestResponse PatchObject(string id, ObjectDataModel body)
        {
            var request = CreateRequest($"objects/{id}", Method.Patch);
            request.AddJsonBodyIgnoreNulls(body);
            return ExecuteRequest(request);
        }

        public RestResponse GetObject(string id)
        {
            var request = CreateRequest($"objects/{id}", Method.Get);
            return ExecuteRequest(request);
        }

        public RestResponse DeleteObject(string id)
        {
            var request = CreateRequest($"objects/{id}", Method.Delete);
            return ExecuteRequest(request);
        }


    }
}
