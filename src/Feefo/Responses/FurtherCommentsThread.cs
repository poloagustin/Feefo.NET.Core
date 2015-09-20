using System.Collections.Generic;
using Feefo.JsonConverters;
using Newtonsoft.Json;

namespace Feefo.Responses
{
    public class FurtherCommentsThread
    { 
        [JsonProperty(PropertyName = "POST")]
        [JsonConverter(typeof(SingleValueArrayConverter<Post>))]
        public List<Post> Posts { get; set; }
    }
}