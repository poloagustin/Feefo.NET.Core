using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using NUnit.Framework;

namespace Feefo.Tests
{
    [TestFixture]
    public class FeefoClientTests
    {
        private StubHttpMessageHandler _httpMessageHandler;
        private FeefoClient _client;
        private FeefoClientResponse _result;

        [TestFixtureSetUp]
        public void GivenAFeefoClientWithAFakeClientHandler()
        {
            var baseUri = "http://www.feefo.com/feefo/xmlfeed.jsp";
            var feefoSettings = new FeefoSettings() {BaseUri = new Uri(baseUri), Logon = "www.examplesupplier.com" };

            _httpMessageHandler = new StubHttpMessageHandler(new Uri($"{baseUri}?logon={feefoSettings.Logon}&json=true"),
                                            new ResourceHelper().GetStringResource("Feefo.Tests.FeefoRssFeed.json"));
            _client = new FeefoClient(_httpMessageHandler, feefoSettings);
        }

        [SetUp]
        public void WhenGettingFeedback()
        {
            _result = _client.GetFeedback().Result;
        }

        [Test]
        public void ThenTheSummaryIsCorrect()
        {
            Assert.That(_result.FeedbackList.SUMMARY.AVERAGE, Is.EqualTo(85));
            Assert.That(_result.FeedbackList.SUMMARY.BEST, Is.EqualTo(100));
            Assert.That(_result.FeedbackList.SUMMARY.COUNT, Is.EqualTo(3863));
            Assert.That(_result.FeedbackList.SUMMARY.FEEDGENERATION, Is.EqualTo("Tue Sep 15 22:20:39 BST 2015"));
            Assert.That(_result.FeedbackList.SUMMARY.LIMIT, Is.EqualTo(20));
            Assert.That(_result.FeedbackList.SUMMARY.MODE, Is.EqualTo("service"));
            Assert.That(_result.FeedbackList.SUMMARY.PRODUCTBAD, Is.EqualTo(323));
            Assert.That(_result.FeedbackList.SUMMARY.PRODUCTEXCELLENT, Is.EqualTo(1009));
            Assert.That(_result.FeedbackList.SUMMARY.PRODUCTGOOD, Is.EqualTo(1233));
            Assert.That(_result.FeedbackList.SUMMARY.PRODUCTPOOR, Is.EqualTo(308));
            Assert.That(_result.FeedbackList.SUMMARY.SERVICEBAD, Is.EqualTo(426));
            Assert.That(_result.FeedbackList.SUMMARY.SERVICEEXCELLENT, Is.EqualTo(5798));
            Assert.That(_result.FeedbackList.SUMMARY.SERVICEGOOD, Is.EqualTo(1084));
            Assert.That(_result.FeedbackList.SUMMARY.SERVICEPOOR, Is.EqualTo(203));
            Assert.That(_result.FeedbackList.SUMMARY.START, Is.EqualTo(1));
            Assert.That(_result.FeedbackList.SUMMARY.SUPPLIERLOGO, Is.EqualTo("http://www.feefo.com/feefo/getnonpublicfile.jsp?vendorimage=13&vendorimageext=file.png"));
            Assert.That(_result.FeedbackList.SUMMARY.TITLE, Is.EqualTo("Example Supplier Ltd."));
            Assert.That(_result.FeedbackList.SUMMARY.TOTALPRODUCTCOUNT, Is.EqualTo(2890));
            Assert.That(_result.FeedbackList.SUMMARY.TOTALRESPONSES, Is.EqualTo(3871));
            Assert.That(_result.FeedbackList.SUMMARY.TOTALSERVICECOUNT, Is.EqualTo(3866));
            Assert.That(_result.FeedbackList.SUMMARY.VENDORLOGON, Is.EqualTo("www.examplesupplier.com"));
            Assert.That(_result.FeedbackList.SUMMARY.VENDORREF, Is.Not.Null);
            Assert.That(_result.FeedbackList.SUMMARY.WORST, Is.EqualTo(0));
        }
    }
}
