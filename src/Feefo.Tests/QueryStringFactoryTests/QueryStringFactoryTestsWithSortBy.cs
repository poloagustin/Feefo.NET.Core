using NUnit.Framework;

namespace Feefo.Tests.QueryStringFactoryTests
{
    [TestFixture(SortBy.Date, "date")]
    [TestFixture(SortBy.Relevance, "relevance")]
    [TestFixture(SortBy.Description, "description")]
    [TestFixture(SortBy.ServiceFeedback, "service_feedback")]
    [TestFixture(SortBy.ProductFeedback, "product_feedback")]
    public class QueryStringFactoryTestsWithSortBy : QueryStringFactoryTests
    {
        private readonly SortBy _sortBy;
        private readonly string _expected;

        public QueryStringFactoryTestsWithSortBy(SortBy sortBy, string expected)
        {
            _sortBy = sortBy;
            _expected = expected;
        }
        
        protected override FeedbackRequest WithFeedbackRequest()
        {
            return new FeedbackRequest()
            {
                SortBy = _sortBy
            };
        }

        [Test]
        public void ThenTheQueryStringContainsSortBy()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("sortby"), Is.True);
            Assert.That(lookup["sortby"], Is.EqualTo(_expected));
        }
    }
}