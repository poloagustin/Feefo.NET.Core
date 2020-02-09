using Newtonsoft.Json;

namespace Feefo.Core.Responses
{

    public class Rootobject
    {
        [JsonProperty(PropertyName = "FEEDBACKLIST")]
        public FeedbackList FeedbackList { get; set; }
    }
}