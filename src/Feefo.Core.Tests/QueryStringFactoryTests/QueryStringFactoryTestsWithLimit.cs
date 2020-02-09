using System.Linq;
using Feefo.Core.Requests;
using NUnit.Framework;

namespace Feefo.Core.Tests.QueryStringFactoryTests
{
    [TestFixture]
    public class QueryStringFactoryTestsWithLimit : QueryStringFactoryTests
    {
        private int _limit;

        protected override FeedbackRequest WithFeedbackRequest()
        {
            _limit = 99;
            return new FeedbackRequest()
            {
                Limit = _limit
            };
        }

        [Test]
        public void ThenTheQueryStringContainsLimit()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("limit"), Is.True);
            Assert.That(lookup["limit"], Is.EqualTo(_limit.ToString()));
        }
    }
}