using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Feefo.Tests
{
    public class StubHttpMessageHandler : HttpMessageHandler
    {
        private readonly Uri _catchUri;
        private readonly string _response;

        public StubHttpMessageHandler(Uri catchUri, string response)
        {
            _catchUri = catchUri;
            _response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri == _catchUri)
            {
                var content = new StringContent(_response,
                    Encoding.UTF8, "application/json" /* its json but feefo lies to us */);

                return Task.FromResult(new HttpResponseMessage() { Content = content });
            }

            throw new Exception("Uri did not match");
        }
    }
}