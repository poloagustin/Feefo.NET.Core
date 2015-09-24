using System;
using System.Security.Policy;
using System.Threading.Tasks;
using Feefo.Requests;
using NUnit.Framework;

namespace Feefo.AcceptanceTests
{
    [TestFixture]
    public class GettingFeedbackTests
    {
        private FeefoClient _client;
        private FeefoClientResponse _result;

        [TestFixtureSetUp]
        public void GivenAFeefoClientWithAnExampleSupplier()
        {
            var feefoSettings = new FeefoSettings("www.examplesupplier.com");

            _client = new FeefoClient(feefoSettings);
        }

        [SetUp]
        public void WhenGettingFeedback()
        {
            var feedbackRequest = new FeedbackRequest()
            {
                Limit = 50,
                Mode = Mode.ServiceAndProduct,
                Sort = new Sort(SortBy.Date, Order.Ascending),
                Since = Since.Month
            };
            _result = _client.GetFeedbackAsync(feedbackRequest).Result;
        }

        [Test]
        public void ThenSummaryIsReturned()
        {
            Assert.That(_result.FeedbackList.Summary, Is.Not.Null);
        }

        [Test]
        public void ThenFeedbackIsReturned()
        {
            Assert.That(_result.FeedbackList.Feedback, Is.Not.Empty);
        }
    }
}
