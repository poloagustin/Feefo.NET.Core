using NUnit.Framework;

namespace Feefo.Tests.QueryStringFactoryTests
{
    [TestFixture(Since.Week, "week")]
    [TestFixture(Since.Month, "month")]
    [TestFixture(Since.SixMonths, "6months")]
    [TestFixture(Since.Year, "year")]
    public class QueryStringFactoryTestsWithSince : QueryStringFactoryTests
    {
        private readonly Since _since;
        private readonly string _expected;

        public QueryStringFactoryTestsWithSince(Since since, string expected)
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