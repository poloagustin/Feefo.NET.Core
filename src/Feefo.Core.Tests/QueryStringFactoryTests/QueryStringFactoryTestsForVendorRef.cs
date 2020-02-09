using System;
using Feefo.Core.Requests;
using NUnit.Framework;

namespace Feefo.Core.Tests.QueryStringFactoryTests
{
    [TestFixture]
    public class QueryStringFactoryTestsForVendorRef : QueryStringFactoryTests
    {
        private string _vendorRef;

        protected override FeedbackRequest WithFeedbackRequest()
        {
            _vendorRef = Guid.NewGuid().ToString();

            return new FeedbackRequest()
            {
                VendorRef = _vendorRef
            };
        }

        [Test]
        public void ThenTheQueryStringContainsVendorRef()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("vendorref"), Is.True);
            Assert.That(lookup["vendorref"], Is.EqualTo(_vendorRef));
        }
    }
}