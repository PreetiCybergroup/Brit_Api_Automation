using NUnit.Framework.Interfaces;

namespace Brit_API_Automation.Helpers
{
    /// <summary>
    /// Logs the outcome of NUnit test execution to the ExtentReports system.
    /// </summary>
    public static class TestStatusLogger
    {
        /// <summary>
        /// Evaluates the current test result and logs its status to the ExtentReport.
        /// Logs as Pass, Fail, or Info depending on the outcome.
        /// </summary>
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
