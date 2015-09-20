using System;
using Newtonsoft.Json;

namespace Feefo.Responses
{
    public class Feedback
    {
        [JsonProperty(PropertyName = "COUNT")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "CUSTOMERCOMMENT")]
        public string CustomerComment { get; set; }

        [JsonProperty(PropertyName = "DATE")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "DESCRIPTION")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "FACEBOOKSHARELINK")]
        public string FacebookShareLink { get; set; }

        [JsonProperty(PropertyName = "FEEDBACKID")]
        public int FeedbackId { get; set; }

        [JsonProperty(PropertyName = "HREVIEWDATE")]
        public DateTime HReviewDate { get; set; }

        [JsonProperty(PropertyName = "HREVIEWRATING")]
        public int HReviewRating { get; set; }

        [JsonProperty(PropertyName = "LINK")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "PRODUCTCODE")]
        public object ProductCode { get; set; }

        [JsonProperty(PropertyName = "PRODUCTRATING")]
        public string ProductRating { get; set; }

        [JsonProperty(PropertyName = "READMOREURL")]
        public string ReadmMoreUrl { get; set; }

        [JsonProperty(PropertyName = "SERVICERATING")]
        public string ServiceRating { get; set; }

        [JsonProperty(PropertyName = "SHORTCUSTOMERCOMMENT")]
        public string ShortCustomerComment { get; set; }

        [JsonProperty(PropertyName = "FURTHERCOMMENTSTHREAD")]
        public FurtherCommentsThread FurtherCommentsThread { get; set; }

        [JsonProperty(PropertyName = "PRODUCTLATEST")]
        public string ProductLatest { get; set; }

        [JsonProperty(PropertyName = "SERVICELATEST")]
        public string ServiceLatest { get; set; }

        [JsonProperty(PropertyName = "SHORTVENDORCOMMENT")]
        public string ShortVendorComment { get; set; }

        [JsonProperty(PropertyName = "VENDORCOMMENT")]
        public string VendorComment { get; set; }
    }
}