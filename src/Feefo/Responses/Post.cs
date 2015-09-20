using System;
using Newtonsoft.Json;

namespace Feefo.Responses
{
    public class Post
    {
        /// <summary>
        /// The date the further response was added.
        /// </summary>
        [JsonProperty(PropertyName = "DATE")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Text of a response from the vendor.
        /// </summary>
        [JsonProperty(PropertyName = "VENDORCOMMENT")]
        public string VendorComment { get; set; }

        /// <summary>
        /// Text of a follow up comment left by the customer.
        /// </summary>
        [JsonProperty(PropertyName = "CUSTOMERCOMMENT")]
        public string CustomerComment { get; set; }

        /// <summary>
        /// The product rating.
        /// </summary>
        [JsonProperty(PropertyName = "PRODUCTRATING")]
        public string ProductRating { get; set; }

        /// <summary>
        /// The service rating.
        /// </summary>
        [JsonProperty(PropertyName = "SERVICERATING")]
        public string ServiceRating { get; set; }
    }
}