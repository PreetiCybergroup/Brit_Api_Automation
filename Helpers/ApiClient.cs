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
    /// <summary>
    /// Provides methods to interact with the Brit API using RestSharp.
    /// Supports CRUD operations and request execution for automated testing.
    /// </summary>
    public class ApiClient
    {
        private readonly RestClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class with the specified base URL.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API.</param>
        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        /// <summary>
        /// Executes a synchronous API request.
        /// </summary>
        /// <param name="_request">The RestSharp request to execute.</param>
        /// <returns>The API response.</returns>
        public RestResponse ExecuteRequest(RestRequest _request)
        {
            return _client.Execute(_request);
        }

        /// <summary>
        /// Executes an asynchronous API request.
        /// </summary>
        /// <param name="_request">The RestSharp request to execute.</param>
        /// <returns>A task representing the asynchronous operation, with the API response.</returns>
        public async Task<RestResponse> ExecuteRequestAsync(RestRequest _request)
        {
            return await _client.ExecuteAsync(_request);
        }

        /// <summary>
        /// Creates a new RestSharp request with the specified resource and HTTP method.
        /// Adds a default JSON content-type header.
        /// </summary>
        /// <param name="resource">The API endpoint or resource path.</param>
        /// <param name="method">The HTTP method to use.</param>
        /// <returns>A configured RestRequest object.</returns>
        public RestRequest CreateRequest(string? resource, Method method)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", "application/json");
            return request;
        }

        /// <summary>
        /// Sends a POST request to create a new object in the API.
        /// </summary>
        /// <param name="body">The object data to send in the request body.</param>
        /// <returns>The ID of the newly created object.</returns>
        public string CreateObject(ObjectDataModel body)
        {
            var request = CreateRequest("objects", Method.Post);
            request.AddJsonBody(body);
            var response = ExecuteRequest(request);
            return JObject.Parse(response.Content)["id"].ToString();
        }

        /// <summary>
        /// Sends a PATCH request to update an existing object.
        /// </summary>
        /// <param name="id">The ID of the object to update.</param>
        /// <param name="body">The updated object data.</param>
        /// <returns>The API response.</returns>
        public RestResponse PatchObject(string id, ObjectDataModel body)
        {
            var request = CreateRequest($"objects/{id}", Method.Patch);
            request.AddJsonBodyIgnoreNulls(body);
            return ExecuteRequest(request);
        }

        /// <summary>
        /// Sends a GET request to retrieve an object by ID.
        /// </summary>
        /// <param name="id">The ID of the object to retrieve.</param>
        /// <returns>The API response.</returns>
        public RestResponse GetObject(string id)
        {
            var request = CreateRequest($"objects/{id}", Method.Get);
            return ExecuteRequest(request);
        }

        /// <summary>
        /// Sends a DELETE request to remove an object by ID.
        /// </summary>
        /// <param name="id">The ID of the object to delete.</param>
        /// <returns>The API response.</returns>
        public RestResponse DeleteObject(string id)
        {
            var request = CreateRequest($"objects/{id}", Method.Delete);
            return ExecuteRequest(request);
        }
    }
}
