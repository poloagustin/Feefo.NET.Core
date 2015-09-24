using System.Linq;
using Feefo.Requests;
using NUnit.Framework;

namespace Feefo.Tests.QueryStringFactoryTests
{
    [TestFixture(Mode.Service, "service")]
    [TestFixture(Mode.Product, "product")]
    [TestFixture(Mode.ServiceAndProduct, "both")]
    [TestFixture(Mode.ProductOnly, "productonly")]
    [TestFixture(Mode.ProductCo, "productco")]
    public class QueryStringFactoryTestsWithMode : QueryStringFactoryTests
    {
        private readonly Mode _mode;
        private readonly string _expected;

        public QueryStringFactoryTestsWithMode(Mode mode, string expected)
        {
            _mode = mode;
            _expected = expected;
        }

        protected override FeedbackRequest WithFeedbackRequest()
        {
            return new FeedbackRequest()
            {
                Mode = _mode
            };
        }

        [Test]
        public void ThenTheQueryStringContainsMode()
        {
            var lookup = GetQueryLookup();

            Assert.That(lookup.ContainsKey("mode"), Is.True);
            Assert.That(lookup["mode"], Is.EqualTo(_expected));
        }
    }
}