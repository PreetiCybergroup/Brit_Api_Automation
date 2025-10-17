using Brit_API_Automation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brit_API_Automation.Tests
{
    /// <summary>
    /// Base test class for API automation.
    /// Initializes reporting once before each test run and API client setup for each test.
    /// Handles cleanup and reporting teardown.
    /// </summary>
    public class BaseTest
    {
        /// <summary>
        /// Instance of the API client used for sending requests.
        /// </summary>
        public ApiClient _apiClient;

        /// <summary>
        /// Stores the response ID returned from API calls for cleanup.
        /// </summary>
        protected string responseId;

        /// <summary>
        /// Initializes the ExtentReport once before any tests run.
        /// Creates a test entry and logs the start of the test.
        /// </summary>
        [OneTimeSetUp]
        public void Initialize()
        {
            if (ReportManager.extent == null)
                ReportManager.InitReport();

            ReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
            ReportManager.LogInfo("Test started: " + TestContext.CurrentContext.Test.Name);
        }

        /// <summary>
        /// Sets up the API client before each test.
        /// </summary>
        [SetUp]
        public void Setup() 
        {
           _apiClient = new ApiClient(ConfigHelper.GetBaseUrl());
        }

        /// <summary>
        /// Cleans up after each test.
        /// Deletes any created object using responseId and logs the outcome.
        /// </summary>
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

        /// <summary>
        /// Flushes the ExtentReport once after all tests have run.
        /// </summary>
        [OneTimeTearDown]
        public void FlushReport()
        {
            ReportManager.FlushReport();
        }
    }
}
