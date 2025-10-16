README: Brit API Automation with NUnit
Overview
This project contains automated API tests for the Brit application using:

NUnit for test framework

RestSharp for HTTP requests

ExtentReports for reporting

.NET 8.0 as the runtime

Getting Started
✅ Prerequisites
Make sure you have the following installed:

.NET SDK 8.0

Visual Studio 2022+ or VS Code

NuGet packages:

RestSharp

NUnit

ExtentReports

Newtonsoft.Json

You can install them via NuGet Package Manager or CLI:

dotnet add package RestSharp
dotnet add package NUnit
dotnet add package ExtentReports
dotnet add package Newtonsoft.Json
dotnet add package NUnit
dotnet add package NUnit.Analyzers
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Binder
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Microsoft.Extensions.Configuration.FileExtensions


Project Structure
Brit_API_Automation/ 
├── Dependencies/ # External packages and libraries (collapsed) 
├── Helpers/ # Utility classes and helper functions 
│  ├── ApiClient.cs  
|  ├── ConfigHelper.cs 
|  ├── ObjectDataHelper.cs  
|  ├── ReportManager.cs 
│  ├── TestRequestExtensions.cs 
│  └── TestStatusLogger.cs 
├── Models/ # Data models used in API requests/responses (collapsed) 
|   |- AppSettingsModel.cs
|   |- ObjectDataModel.cs
├── Reports/ # Generated test reports │ 
├── TestData/ # JSON files for test payloads 
│   ├── PatchData.json 
│   └── PostData.json 
├── Tests/ # Test classes and base test setup 
│   ├── BaseTest.cs 
│   └── PatchObjectTest.cs 
├── appsettings.json # Application configuration settings 
└── README.md # Project documentation


Running the Tests
You can run the tests using the .NET CLI:


dotnet test

Or from Visual Studio:
Open the Test Explorer
Click Run All

Viewing the Report
After test execution, an HTML report will be generated in:

Code
D:/Brit_API_Auto/Reports/
Open the latest ExtentReport_YYYYMMDD_HHMMSS.html file in your browser.

Customization
To change the report location, update ReportManager.InitReport() in Helpers/ReportManager.cs.
To add environment info, use extent.AddSystemInfo("Key", "Value").


Observations and Findings :-
PATCH Request Behavior and Workaround
Issue: Reserved ID Restriction
When executing a PATCH request on certain predefined or existing object IDs, the API responds with:

Code
405 Method not allowed: Cannot update reserved IDs
This indicates that the API restricts updates to system-reserved or protected IDs, preventing modification through PATCH operations.

Workaround Strategy
To validate PATCH functionality without triggering this restriction:
Create a new object using a POST request
This ensures the object has a valid, non-reserved ID.
The object is created with editable data.
Execute the PATCH request on the newly created object
This allows verification of PATCH behavior under normal conditions.
Clean up using DELETE in the teardown
The object is deleted after the test completes.
This maintains a clean test environment and avoids data clutter.

Author
Created by: 
Name: Preeti Gupta 
