using System.Linq;
using NUnit.Framework;

namespace Feefo.Tests.QueryStringFactoryTests
{
    [TestFixture(SortBy.Date, Order.Ascending, "date", "asc")]
    [TestFixture(SortBy.Date, Order.Descending, "date", "desc")]
    [TestFixture(SortBy.Relevance, Order.Ascending, "relevance", "asc")]
    [TestFixture(SortBy.Relevance, Order.Descending, "relevance", "desc")]
    [TestFixture(SortBy.Description, Order.Ascending, "description", "asc")]
    [TestFixture(SortBy.Description, Order.Descending, "description", "desc")]
    [TestFixture(SortBy.ServiceFeedback, Order.Ascending, "service_feedback", "asc")]
    [TestFixture(SortBy.ServiceFeedback, Order.Descending, "service_feedback", "desc")]
    [TestFixture(SortBy.ProductFeedback, Order.Ascending, "product_feedback", "asc")]
    [TestFixture(SortBy.ProductFeedback, Order.Descending, "product_feedback", "desc")]
    public class QueryStringFactoryTestsWithSort : QueryStringFactoryTests
    {
        private readonly SortBy _sortBy;
        private readonly Order _order;
        private readonly string _expectedSortBy;
        private readonly string _expectedOrder;

        public QueryStringFactoryTestsWithSort(SortBy sortBy, Order order, string expectedSortBy, string expectedOrder)
        {
            _sortBy = sortBy;
            _order = order;
            _expectedSortBy = expectedSortBy;
            _expectedOrder = expectedOrder;
        }

        protected override FeedbackRequest WithFeedbackRequest()
        {
            var sort = new Sort(_sortBy, _order);

            return new FeedbackRequest()
            {
                Sort = sort
            };
        }

        [Test]
        public void ThenTheQueryStringContainsSortBy()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("sortby"), Is.True);
            Assert.That(lookup["sortby"], Is.EqualTo(_expectedSortBy));
        }

        [Test]
        public void ThenTheQueryStringContainsOrder()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("order"), Is.True);
            Assert.That(lookup["order"], Is.EqualTo(_expectedOrder));
        }
    }
}