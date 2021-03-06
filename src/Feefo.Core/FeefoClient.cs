﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Feefo.Core.Requests;
using Feefo.Core.Responses;
using Newtonsoft.Json.Linq;

namespace Feefo.Core
{
    public class FeefoClient : IFeefoClient, IDisposable
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
            var httpClient = new HttpClient(_handler)
            {
                BaseAddress = _feefoSettings.BaseUri
            };
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
