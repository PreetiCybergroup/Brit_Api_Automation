using Brit_API_Automation.Helpers;
using Brit_API_Automation.Model;
using Microsoft.VisualStudio.TestPlatform.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace Brit_API_Automation.Tests
{
    public class PatchObjectTest : BaseTest
    {
        

        [Test]
        public void PatchObject_ShouldReturn200_WhenValidData()
        {
            JObject updatedResponse;
            
            //Execute Patch Request
            ObjectDataModel patchBody = ObjectDataHelper.ReadDataFromJsonFile("PatchData.json");
            var patchResponse = _apiClient.PatchObject(patchBody.id, patchBody);
            if((string.IsNullOrEmpty(patchBody.id)) || (patchResponse.StatusCode == HttpStatusCode.BadRequest))
            {
                ReportManager.LogInfo("PatchData.json must include a valid 'id' field");
                throw new ArgumentException("PatchData.json must include a valid 'id' field.");
            }
                
            if (patchResponse.StatusCode == HttpStatusCode.MethodNotAllowed)
            {
                ReportManager.LogWarn("PATCH failed with 405. Creating new object...");
                
                // Create new object via POST
                ObjectDataModel postBody = ObjectDataHelper.ReadDataFromJsonFile("PostData.json");
                

                string postId = _apiClient.CreateObject(postBody);

                ReportManager.LogInfo($"New object created with ID: {postId}");
                
                //Retry Patch with new id
                var retryPatchResponse = _apiClient.PatchObject(postId, patchBody);
                updatedResponse = JObject.Parse(retryPatchResponse.Content);
                
                //Assertions to verify API Status code and response
                Assert.That(retryPatchResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(updatedResponse["name"].ToString(), Is.EqualTo(patchBody.name));
                ReportManager.LogInfo("PATCH succeeded on new object.");
                
                responseId = postId;
                ReportManager.LogInfo($"Final object ID used for PATCH: {responseId}");
            }
            else
            {
                updatedResponse = JObject.Parse(patchResponse.Content);
                Assert.That(patchResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(updatedResponse["name"].ToString(), Is.EqualTo(patchBody.name));
                ReportManager.LogInfo("PATCH succeeded on original object.");
            }
        }

        
    }
}