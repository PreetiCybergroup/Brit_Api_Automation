using Brit_API_Automation.Helpers;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
namespace Brit_API_Automation.Helpers
{
    public static class TestStatusLogger
    {
        public static void LogTestOutcome()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (status)
            {
                case TestStatus.Passed:
                    ReportManager.LogPass("Test passed");
                    break;
                case TestStatus.Failed:
                    ReportManager.LogFail("Test failed: " + message);
                    break;
                default:
                    ReportManager.LogInfo("Test completed with status: " + status);
                    break;
            }
        }
    }
}






