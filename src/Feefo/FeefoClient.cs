using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Feefo.Requests;
using Feefo.Responses;

namespace Feefo
{
    public class FeefoClient
    {
        private readonly HttpMessageHandler _handler;
        private readonly IQueryStringFactory _queryStringFactory;
        private readonly IFeefoSettings _feefoSettings;

        public FeefoClient(HttpMessageHandler handler, IQueryStringFactory queryStringFactory, IFeefoSettings feefoSettings)
        {
            _handler = handler;
            _queryStringFactory = queryStringFactory;
            _feefoSettings = feefoSettings;
        }

        public FeefoClient(IFeefoSettings feefoSettings)
            : this(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            }, new QueryStringFactory(), feefoSettings)
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
            var queryString = _queryStringFactory.Create(_feefoSettings.Logon, new FeedbackRequest());
            
            var response = await httpClient.GetAsync(queryString)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsAsync<Rootobject>()
                .ConfigureAwait(false);

            return new FeefoClientResponse(content.FeedbackList);
        }
    }
}
