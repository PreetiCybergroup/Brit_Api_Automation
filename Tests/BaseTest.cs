using Brit_API_Automation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brit_API_Automation.Tests
{
    public class BaseTest
    {
        public ApiClient _apiClient;
        protected string responseId;

        [OneTimeSetUp]
        public void Initialize()
        {
            if (ReportManager.extent == null)
                ReportManager.InitReport();

            ReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
            ReportManager.LogInfo("Test started: " + TestContext.CurrentContext.Test.Name);
        }

        [SetUp]
        public void Setup() 
        {
           _apiClient = new ApiClient(ConfigHelper.GetBaseUrl());
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine($"Updated responseId {responseId}");
            //_apiClient._client.Dispose();
            if(!string.IsNullOrEmpty(responseId))
            {
                _apiClient.DeleteObject(responseId);
                TestContext.Progress.WriteLine($"Deleted responseId {responseId}");
            }

            TestStatusLogger.LogTestOutcome();
            
        }

        [OneTimeTearDown]
        public void FlushReport()
        {
            ReportManager.FlushReport();
        }
    }
}
