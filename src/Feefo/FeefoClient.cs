using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Feefo.Responses;
using Newtonsoft.Json;

namespace Feefo
{
    public class FeefoClient
    {
        private readonly HttpMessageHandler _handler;
        private readonly FeefoSettings _feefoSettings;

        public FeefoClient(HttpMessageHandler handler, FeefoSettings feefoSettings)
        {
            _handler = handler;
            _feefoSettings = feefoSettings;
        }
        
        public FeefoClient(FeefoSettings feefoSettings)
            : this(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            }, feefoSettings)
        {
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = HttpClientFactory.Create(_handler);
            
            httpClient.BaseAddress = _feefoSettings.BaseUri;

            return httpClient;
        }

        public async Task<FeefoClientResponse> GetFeedback()
        {
            var httpClient = CreateHttpClient();

            var response = await httpClient.GetAsync($"?logon={_feefoSettings.Logon}&json=true")
                                        .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var mediaTypeFormatterCollection = CreateMediaTypeFormatterCollection();

            var content = await response.Content.ReadAsAsync<Rootobject>(mediaTypeFormatterCollection)
                                            .ConfigureAwait(false);

            return new FeefoClientResponse(content.FeedbackList);
        }


        private IEnumerable<MediaTypeFormatter> CreateMediaTypeFormatterCollection()
        {
            var jsonMediaFormatter = new JsonMediaTypeFormatter();

            // Feefo tells us its text/xml when its really json... lies!
            jsonMediaFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));

            var collection = new List<MediaTypeFormatter>()
            {
                jsonMediaFormatter
            };

            return collection;
        }
    }

    public class FeefoClientResponse
    {
        public FeefoClientResponse(FeedbackList feedbackList)
        {
            FeedbackList = feedbackList;
        }

        public FeedbackList FeedbackList { get; }
    }
}
