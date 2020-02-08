using Newtonsoft.Json;

namespace Feefo.Responses
{

    public class Rootobject
    {
        [JsonProperty(PropertyName = "FEEDBACKLIST")]
        public FeedbackList FeedbackList { get; set; }
    }
}