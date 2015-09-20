using System.Collections.Generic;
using Newtonsoft.Json;

namespace Feefo.Responses
{
    public class FeedbackList
    {
        [JsonProperty(PropertyName = "FEEDBACK")]
        public List<Feedback> Feedback { get; set; }

        /// <summary>
        /// Top level element for the feed summary.
        /// </summary>
        [JsonProperty(PropertyName = "SUMMARY")]
        public Summary Summary { get; set; }
    }
}