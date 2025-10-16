using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace Brit_API_Automation.Helpers
{
    public static class ReportManager
    {


        public static ExtentReports extent;
        public static ExtentTest test;

        public static void InitReport()
        {
            //var htmlReporter = new ExtentHtmlReporter("ExtentReport.html");
            //extent = new AventStack.ExtentReports.ExtentReports();
            //extent.AttachReporter(htmlReporter);


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

        public static void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }

        public static void LogInfo(string message)
        {
            test.Info(message);
        }

        public static void LogPass(string message)
        {
            test.Pass(message);
        }

        public static void LogFail(string message)
        {
            test.Fail(message);
            
        }

        public static void LogWarn(string message)
        {
            test.Warning(message);
        }

        public static void FlushReport()
        {
            extent.Flush();
        }
    }

}
