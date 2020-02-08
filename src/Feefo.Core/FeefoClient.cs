using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Feefo.Requests;
using Feefo.Responses;
using Newtonsoft.Json.Linq;

namespace Feefo
{
    public class FeefoClient : IFeefoClient, IDisposable
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpMessageHandler _handler;
        private readonly IQueryStringFactory _queryStringFactory;
        private readonly IFeefoSettings _feefoSettings;

        public FeefoClient(IHttpClientFactory httpClientFactory, HttpMessageHandler handler, IQueryStringFactory queryStringFactory, IFeefoSettings feefoSettings)
        {
            _httpClientFactory = httpClientFactory;
            _handler = handler;
            _queryStringFactory = queryStringFactory;
            _feefoSettings = feefoSettings;
        }

        public FeefoClient(IHttpClientFactory httpClientFactory, IFeefoSettings feefoSettings)
            : this(httpClientFactory,new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            }, new QueryStringFactory(), feefoSettings)
        {
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = _feefoSettings.BaseUri;
            return httpClient;
        }

        public Task<FeefoClientResponse> GetFeedbackAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetFeedbackAsync(new FeedbackRequest(), cancellationToken);
        }

        public async Task<FeefoClientResponse> GetFeedbackAsync(FeedbackRequest feedbackRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            var httpClient = CreateHttpClient();
            var queryString = _queryStringFactory.Create(_feefoSettings.Logon, feedbackRequest);

            var response = await httpClient.GetAsync(queryString);

            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();

            var parsedContent = JObject.Parse(jsonContent);

            var content = parsedContent.ToObject<Rootobject>();

            return new FeefoClientResponse(content?.FeedbackList);
        }

        public void Dispose()
        {
            _handler.Dispose();
        }
    }
}
