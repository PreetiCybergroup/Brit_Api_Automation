using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Brit_API_Automation.Helpers
{
    /// <summary>
    /// Manages ExtentReports lifecycle and logging for API automation tests.
    /// Provides methods to initialize reports, create test entries, and log test outcomes.
    /// </summary>
    public static class ReportManager
    {
        /// <summary>
        /// The main ExtentReports instance used to generate and flush reports.
        /// </summary>
        public static ExtentReports extent;

        /// <summary>
        /// The current test instance used for logging steps and outcomes.
        /// </summary>
        public static ExtentTest test;

        /// <summary>
        /// Initializes the ExtentReports system and configures the Spark reporter.
        /// Creates a timestamped HTML report in the Reports folder at the project root.
        /// </summary>
        public static void InitReport()
        {
            // Define the report folder and ensure it exists
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string rootDir = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
            string reportDir = Path.Combine(rootDir, "Reports");

            if (!Directory.Exists(reportDir))
            {
                Directory.CreateDirectory(reportDir);
            }

            // Optional: Add timestamp to avoid overwriting reports
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string reportPath = Path.Combine(reportDir, $"ExtentReport_{timestamp}.html");

            // Initialize Spark Reporter
            var sparkReporter = new ExtentSparkReporter(reportPath);
            sparkReporter.Config.DocumentTitle = "API Automation Report";
            sparkReporter.Config.ReportName = "RestSharp + NUnit Test Results";

            // Attach reporter to ExtentReports
            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);

            // Optional: Add system/environment info
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Tester", "Preeti GUpta");
            extent.AddSystemInfo("Platform", Environment.OSVersion.ToString());
        }

        /// <summary>
        /// Creates a new test entry in the report with the specified test name.
        /// </summary>
        /// <param name="testName">The name of the test to log.</param>
        public static void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }

        /// <summary>
        /// Logs an informational message to the current test entry.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogInfo(string message)
        {
            test.Info(message);
        }

        /// <summary>
        /// Logs a passed status message to the current test entry.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogPass(string message)
        {
            test.Pass(message);
        }

        /// <summary>
        /// Logs a failed status message to the current test entry.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogFail(string message)
        {
            test.Fail(message);
        }

        /// <summary>
        /// Logs a warning message to the current test entry.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogWarn(string message)
        {
            test.Warning(message);
        }

        /// <summary>
        /// Flushes the report to disk, finalizing all logged entries.
        /// Should be called once after all tests have completed.
        /// </summary>
        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
