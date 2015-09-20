using System;
using System.Security.Policy;
using System.Threading.Tasks;
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
            var feefoSettings = new FeefoSettings()
            {
                BaseUri = new Uri("http://www.feefo.com/feefo/xmlfeed.jsp"),
                Logon = "www.examplesupplier.com"
            };

            _client = new FeefoClient(feefoSettings);
        }

        [SetUp]
        public void WhenGettingFeedback()
        {
            _result = _client.GetFeedback().Result;
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
