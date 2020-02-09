using System.Collections.Generic;
using Newtonsoft.Json;

namespace Feefo.Core.Responses
{
    public class FeedbackList
    {
        /// <summary>
        /// The main containing element of the reviews feed.
        /// </summary>
        [JsonProperty(PropertyName = "FEEDBACK")]
        public List<Feedback> Feedback { get; set; }

        /// <summary>
        /// Top level element for the feed summary.
        /// </summary>
        [JsonProperty(PropertyName = "SUMMARY")]
        public Summary Summary { get; set; }
    }
}