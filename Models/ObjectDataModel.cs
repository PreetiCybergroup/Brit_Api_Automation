
namespace Brit_API_Automation.Model
{
    /// <summary>
    /// Represents the structure of an object used in API requests and responses.
    /// </summary>
    public class ObjectDataModel
    {
        /// <summary>
        /// The unique identifier of the object.
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// The name or title of the object.
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// Additional data attributes associated with the object.
        /// </summary>
        public Data? data { get; set; }
    }

    /// <summary>
    /// Represents detailed attributes of an object, such as specifications and pricing.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// The release year or manufacturing year of the object.
        /// </summary>
        public int? year { get; set; }

        /// <summary>
        /// The price of the object.
        /// </summary>
        public float? price { get; set; }

        /// <summary>
        /// The CPU model used in the object (e.g., for laptops or devices).
        /// </summary>
        public string? cpuModel { get; set; }

        /// <summary>
        /// The size of the hard disk (e.g., "512GB", "1TB").
        /// </summary>
        public string? hardDiskSize { get; set; }
    }
}
