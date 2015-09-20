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
using Newtonsoft.Json.Converters;

namespace Feefo
{
    public class FeefoClient
    {
        private readonly HttpMessageHandler _handler;
        private readonly IFeefoSettings _feefoSettings;

        public FeefoClient(HttpMessageHandler handler, IFeefoSettings feefoSettings)
        {
            _handler = handler;
            _feefoSettings = feefoSettings;
        }

        public FeefoClient(IFeefoSettings feefoSettings)
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
            
            var content = await response.Content.ReadAsAsync<Rootobject>()
                .ConfigureAwait(false);

            return new FeefoClientResponse(content.FeedbackList);
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
