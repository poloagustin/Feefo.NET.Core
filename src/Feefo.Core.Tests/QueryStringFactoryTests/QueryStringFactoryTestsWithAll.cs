using System;
using System.Collections.Generic;
using System.Linq;
using Feefo.Core.Requests;
using NUnit.Framework;

namespace Feefo.Core.Tests.QueryStringFactoryTests
{
    [TestFixture]
    public class QueryStringFactoryTestsWithAll : QueryStringFactoryTests
    {
        protected override FeedbackRequest WithFeedbackRequest()
        {
            return new FeedbackRequest()
            {
                Mode = Mode.Product,
                Sort = new Sort(SortBy.Description, Order.Descending),
                Since = Since.SixMonths,
                VendorRef = "bla",
                Limit = 50
            };
        }


        [Test]
        public void ThenTheQueryStringContainsMode()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("mode"), Is.True);
        }


        [Test]
        public void ThenTheQueryStringContainsSortBy()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("sortby"), Is.True);
        }

        [Test]
        public void ThenTheQueryStringContainsOrder()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("order"), Is.True);
        }

        [Test]
        public void ThenTheQueryStringContainsSince()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("since"), Is.True);
        }

        [Test]
        public void ThenTheQueryStringContainsVendorRef()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("vendorref"), Is.True);
        }

        [Test]
        public void ThenTheQueryStringContainsLimit()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("limit"), Is.True);
        }
    }
}
