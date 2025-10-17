using Brit_API_Automation.Model;
using Newtonsoft.Json;

namespace Brit_API_Automation.Helpers
{
    /// <summary>
    /// Provides helper methods for reading and deserializing test data from JSON files.
    /// </summary>
    public static class ObjectDataHelper
    {
        /// <summary>
        /// Reads a JSON file from the TestData directory and deserializes it into an <see cref="ObjectDataModel"/>.
        /// </summary>
        /// <param name="fileName">The name of the JSON file to read (e.g., "PatchData.json").</param>
        /// <returns>An instance of <see cref="ObjectDataModel"/> populated with data from the file.</returns>
        /// <exception cref="InvalidDataException">Thrown when the JSON structure is invalid or deserialization returns null.</exception>
        public static ObjectDataModel ReadDataFromJsonFile(string fileName)
        {
            string jsonData = File.ReadAllText(Path.Combine("TestData", fileName));
            var data = JsonConvert.DeserializeObject<ObjectDataModel>(jsonData);
            if (data == null)
            {
                ReportManager.LogFail($"Deserialization returned null for file: {fileName}");
                throw new InvalidDataException("Invalid JSON structure.");
            }
            return data;
        }
    }
}

