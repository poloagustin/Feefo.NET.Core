using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Feefo.Tests
{
    [TestFixture]
    public class QueryStringFactoryTests
    {
        private QueryStringFactory _factory;
        private string _logon;
        private string _result;

        [TestFixtureSetUp]
        public void GivenAQueryStringFactory()
        {
            _factory = new QueryStringFactory();
        }

        [SetUp]
        public void WhenCreatingAQueryStringFromALogon()
        {
            _logon = Guid.NewGuid().ToString();
            _result = _factory.Create(_logon, WithFeedbackRequest());
        }

        protected virtual FeedbackRequest WithFeedbackRequest()
        {
            return new FeedbackRequest();
        }

        [Test]
        public void ThenTheQueryStringStartsWithAQuestionMark()
        {
            Assert.That(_result, Is.StringStarting("?"));
        }

        [Test]
        public void ThenTheQueryStringContainsJsonTrue()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("json"), Is.True);
            Assert.That(lookup["json"], Is.EqualTo("true"));
        }

        protected IDictionary<string, string> GetQueryLookup()
        {
            return _result.Substring(1).Split('&')
                .Select(pair => pair.Split('='))
                .ToDictionary(x => x[0], x => x[1]);
        }
    }

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

    [TestFixture(Since.Week, "week")]
    [TestFixture(Since.Month, "month")]
    [TestFixture(Since.SixMonths, "6months")]
    [TestFixture(Since.Year, "year")]
    public class QueryStringFactoryTestsWithRequest : QueryStringFactoryTests
    {
        private readonly Since _since;
        private readonly string _expected;

        public QueryStringFactoryTestsWithRequest(Since since, string expected)
        {
            _since = since;
            _expected = expected;
        }
        
        protected override FeedbackRequest WithFeedbackRequest()
        {
            return new FeedbackRequest()
            {
                Since = _since
            };
        }

        [Test]
        public void ThenTheQueryStringContainsSince()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("since"), Is.True);
            Assert.That(lookup["since"], Is.EqualTo(_expected));
        }
    }
}
