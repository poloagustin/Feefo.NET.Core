using Newtonsoft.Json;

namespace Feefo.Responses
{
    public class Post
    {
        [JsonProperty(PropertyName = "DATE")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "VENDORCOMMENT")]
        public string VendorComment { get; set; }

        [JsonProperty(PropertyName = "CUSTOMERCOMMENT")]
        public string CustomerComment { get; set; }

        [JsonProperty(PropertyName = "PRODUCTRATING")]
        public string ProductRating { get; set; }

        [JsonProperty(PropertyName = "SERVICERATING")]
        public string ServiceRating { get; set; }
    }
}