using System.Collections.Generic;
using Newtonsoft.Json;

namespace Feefo.Responses
{
    public class FeedbackList
    {
        [JsonProperty(PropertyName = "FEEDBACK")]
        public List<Feedback> Feedback { get; set; }
    
        [JsonProperty(PropertyName = "SUMMARY")]
        public Summary Summary { get; set; }
    }
}