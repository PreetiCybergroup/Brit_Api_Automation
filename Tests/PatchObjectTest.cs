using Brit_API_Automation.Helpers;
using Brit_API_Automation.Model;
using Microsoft.VisualStudio.TestPlatform.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace Brit_API_Automation.Tests
{
    /// <summary>
    /// Contains test cases for validating PATCH operations on Brit API objects.
    /// Inherits setup and teardown logic from <see cref="BaseTest"/>.
    /// </summary>
    public class PatchObjectTest : BaseTest
    {
        /// <summary>
        /// Validates that a PATCH request returns HTTP 200 when provided with valid data.
        /// If the PATCH fails due to missing or invalid ID, a new object is created and the PATCH is retried.
        /// </summary>
        [Test]
        public void PatchObject_ShouldReturn200_WhenValidData()
        {
            JObject updatedResponse;

            // Read PATCH payload from file
            ObjectDataModel patchBody = ObjectDataHelper.ReadDataFromJsonFile("PatchData.json");

            // Execute PATCH request
            var patchResponse = _apiClient.PatchObject(patchBody.id, patchBody);

            // Validate ID and handle bad request
            if (string.IsNullOrEmpty(patchBody.id) || patchResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                ReportManager.LogInfo("PatchData.json must include a valid 'id' field");
                throw new ArgumentException("PatchData.json must include a valid 'id' field.");
            }

            // Handle 405 Method Not Allowed by creating a new object
            if (patchResponse.StatusCode == HttpStatusCode.MethodNotAllowed)
            {
                ReportManager.LogWarn("PATCH failed with 405. Creating new object...");

                // Create new object via POST
                ObjectDataModel postBody = ObjectDataHelper.ReadDataFromJsonFile("PostData.json");
                string postId = _apiClient.CreateObject(postBody);
                ReportManager.LogInfo($"New object created with ID: {postId}");

                // Retry PATCH with new ID
                var retryPatchResponse = _apiClient.PatchObject(postId, patchBody);
                updatedResponse = JObject.Parse(retryPatchResponse.Content);

                // Assert response status and content for new Id
                Assert.That(retryPatchResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(updatedResponse["name"].ToString(), Is.EqualTo(patchBody.name));
                ReportManager.LogInfo("PATCH succeeded on new object.");

                // Store ID for cleanup
                responseId = postId;
                ReportManager.LogInfo($"Final object ID used for PATCH: {responseId}");
            }
            else
            {
                // Assert response status and content for original PATCH
                updatedResponse = JObject.Parse(patchResponse.Content);
                Assert.That(patchResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(updatedResponse["name"].ToString(), Is.EqualTo(patchBody.name));
                ReportManager.LogInfo("PATCH succeeded on original object.");
            }
        }
    }
}
