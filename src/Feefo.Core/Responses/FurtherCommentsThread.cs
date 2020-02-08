using System.Collections.Generic;
using Feefo.JsonConverters;
using Newtonsoft.Json;

namespace Feefo.Responses
{
    public class FurtherCommentsThread
    {
        public FurtherCommentsThread()
        {
            Posts = new List<Post>();
        }

        /// <summary>
        /// Contains a customer or vendor responses.
        /// </summary>
        [JsonProperty(PropertyName = "POST")]
        [JsonConverter(typeof(SingleValueArrayConverter<Post>))]
        public List<Post> Posts { get; set; }

        [JsonProperty(PropertyName = "created")]
        public long Created { get; set; }

        [JsonProperty(PropertyName = "sender")]
        public string Sender { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
    }
}