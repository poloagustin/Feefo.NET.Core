using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Feefo.Responses;
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
            var feefoSettings = new FeefoSettings() {BaseUri = new Uri(baseUri), Logon = "www.examplesupplier.com"};

            _httpMessageHandler = new StubHttpMessageHandler(
                new Uri($"{baseUri}?logon={feefoSettings.Logon}&json=true"),
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
            Assert.That(_result.FeedbackList.SUMMARY.SUPPLIERLOGO,
                Is.EqualTo("http://www.feefo.com/feefo/getnonpublicfile.jsp?vendorimage=13&vendorimageext=file.png"));
            Assert.That(_result.FeedbackList.SUMMARY.TITLE, Is.EqualTo("Example Supplier Ltd."));
            Assert.That(_result.FeedbackList.SUMMARY.TOTALPRODUCTCOUNT, Is.EqualTo(2890));
            Assert.That(_result.FeedbackList.SUMMARY.TOTALRESPONSES, Is.EqualTo(3871));
            Assert.That(_result.FeedbackList.SUMMARY.TOTALSERVICECOUNT, Is.EqualTo(3866));
            Assert.That(_result.FeedbackList.SUMMARY.VENDORLOGON, Is.EqualTo("www.examplesupplier.com"));
            Assert.That(_result.FeedbackList.SUMMARY.VendorRef, Is.Not.Null);
            Assert.That(_result.FeedbackList.SUMMARY.WORST, Is.EqualTo(0));
        }
        
        [Test]
        public void ThenTheResultContainsTheCorrectAmountOfFeedback()
        {
            var expectedCount = GetExpectedFeedback().Count;

            Assert.That(_result.FeedbackList.FEEDBACK.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void ThenTheFeedbackIsCorrect()
        {
            var expectedFeedback = GetExpectedFeedback();

            foreach(var feedback in _result.FeedbackList.FEEDBACK)
            {
                var expected = expectedFeedback.First(x => x.FEEDBACKID == feedback.FEEDBACKID);

                Assert.That(feedback.COUNT, Is.EqualTo(expected.COUNT));
                Assert.That(feedback.CUSTOMERCOMMENT, Is.EqualTo(expected.CUSTOMERCOMMENT));
                Assert.That(feedback.DATE, Is.EqualTo(expected.DATE));
                Assert.That(feedback.DESCRIPTION, Is.EqualTo(expected.DESCRIPTION));
                Assert.That(feedback.FACEBOOKSHARELINK, Is.EqualTo(expected.FACEBOOKSHARELINK));
                Assert.That(feedback.HREVIEWDATE, Is.EqualTo(expected.HREVIEWDATE));
                Assert.That(feedback.HREVIEWRATING, Is.EqualTo(expected.HREVIEWRATING));
                Assert.That(feedback.LINK, Is.EqualTo(expected.LINK));
                Assert.That(feedback.PRODUCTCODE, Is.EqualTo(expected.PRODUCTCODE));
                Assert.That(feedback.PRODUCTRATING, Is.EqualTo(expected.PRODUCTRATING));
                Assert.That(feedback.READMOREURL, Is.EqualTo(expected.READMOREURL));
                Assert.That(feedback.SERVICERATING, Is.EqualTo(expected.SERVICERATING));
                Assert.That(feedback.SHORTCUSTOMERCOMMENT, Is.EqualTo(expected.SHORTCUSTOMERCOMMENT));
            }
        }

        public List<Feedback> GetExpectedFeedback()
        {
            return new List<Feedback>()
            {
                new Feedback
                {
                    COUNT = 1,
                    CUSTOMERCOMMENT = "Service rating : Really good service<br/>Product : Good camera for the price.",
                    DATE = "10-Sep-2015",
                    DESCRIPTION = "Konica Minolta Z20",
                    FACEBOOKSHARELINK =
                        "http://www.facebook.com/sharer.php?u=http%3A%2F%2Fwww.feefo.com%2FGB%2Fen%2Freviews%2FExample-Supplier-Ltd%2F%3Fid%3D13%26servicefeedbackid%3D7445488",
                    FEEDBACKID = 7445488,
                    HREVIEWDATE = new DateTime(2015, 09, 10, 11, 25, 58),
                    HREVIEWRATING = 4,
                    LINK =
                        "http://www.examplesupplier.com/product_info.php?products_id=1333OSCommerceOSCommerceOSCommerce",
                    PRODUCTCODE = 133,
                    PRODUCTRATING = "+",
                    READMOREURL =
                        "http://www.feefo.com/GB/en/reviews/Example-Supplier-Ltd/?id=13&servicefeedbackid=7445488",
                    SERVICERATING = "++",
                    SHORTCUSTOMERCOMMENT =
                        "Service rating : Really good service<br/>Product : Good camera for the price."
                },
                new Feedback
                {
                    COUNT = 2,
                    CUSTOMERCOMMENT =
                        "Service rating : This is a test service reviewwwwwwww0000000000000000000001<br/>Product : This is a test product reviewwwwwwww0000000000000000000001",
                    DATE = "08-Sep-2015",
                    DESCRIPTION = "this is a test",
                    FACEBOOKSHARELINK =
                        "http://www.facebook.com/sharer.php?u=http%3A%2F%2Fwww.feefo.com%2FGB%2Fen%2Freviews%2FExample-Supplier-Ltd%2F%3Fid%3D13%26servicefeedbackid%3D7445479",
                    FEEDBACKID = 7445479,
                    FurtherCommentsThread = new FurtherCommentsThread()
                    {
                        POST = new List<Post>()
                        {
                            new Post
                            {
                                DATE = "08-Sep-2015",
                                VENDORCOMMENT = "This is a reply comment through the UI.<br><br>Adrian"
                            },
                            new Post
                            {
                                CUSTOMERCOMMENT = "this is a re-rated review - PRODUCT",
                                DATE = "08-Sep-2015",
                                PRODUCTRATING = "++",
                                SERVICERATING = "++"
                            }
                        }
                    },
                    HREVIEWDATE = new DateTime(2015, 09, 08, 14, 57, 50),
                    LINK = "http://www.examplesupplier.com/product_info.php?products_id=Comment013OSCommerceOSCommerce",
                    PRODUCTCODE = "Comment01",
                    PRODUCTLATEST = "++",
                    PRODUCTRATING = "W",
                    READMOREURL =
                        "http://www.feefo.com/GB/en/reviews/Example-Supplier-Ltd/?id=13&servicefeedbackid=7445479",
                    SERVICELATEST = "++",
                    SERVICERATING = "W",
                    SHORTCUSTOMERCOMMENT =
                        "Service rating : This is a test service reviewwwwwwww0000000000000000000001<br/>Product : This is a test product reviewwwwwwww0000000000000000000001",
                    SHORTVENDORCOMMENT = "This is a reply comment through the UI.<br/><br/>Adrian",
                    VENDORCOMMENT = "This is a reply comment through the UI.<br/><br/>Adrian"
                },
                new Feedback
                {
                    COUNT = 3,
                    CUSTOMERCOMMENT =
                        "Service rating : I had an excellent experience<br/>Product : Great! It's the best thing ever,",
                    DATE = "08-Jul-2015",
                    DESCRIPTION = "Falcon Mach V",
                    FACEBOOKSHARELINK =
                        "http://www.facebook.com/sharer.php?u=http%3A%2F%2Fwww.feefo.com%2FGB%2Fen%2Freviews%2FExample-Supplier-Ltd%2F%3Fid%3D13%26servicefeedbackid%3D7445404",
                    FEEDBACKID = 7445404,
                    FurtherCommentsThread = new FurtherCommentsThread
                    {
                        POST = new List<Post>()
                        {
                            new Post
                            {
                                DATE = "24-Jul-2015",
                                VENDORCOMMENT = "Product :test<br><br>Adrian"
                            },
                            new Post
                            {
                                DATE = "27-Jul-2015",
                                VENDORCOMMENT = "this is a test comment<br><br>Adrian"
                            },
                            new Post
                            {
                                DATE = "27-Jul-2015",
                                VENDORCOMMENT = "Product :this is a test for the second time.<br><br>Adrian"
                            }
                        }
                    },
                    HREVIEWDATE = new DateTime(2015, 07, 08, 21, 57, 22),
                    HREVIEWRATING = 5,
                    LINK = "http://www.examplesupplier.com/product_info.php?products_id=1323OSCommerceOSCommerce",
                    PRODUCTCODE = 132,
                    PRODUCTRATING = "++",
                    READMOREURL =
                        "http://www.feefo.com/GB/en/reviews/Example-Supplier-Ltd/?id=13&servicefeedbackid=7445404",
                    SERVICERATING = "++",
                    SHORTCUSTOMERCOMMENT =
                        "Service rating : I had an excellent experience<br/>Product : Great! It's the best thing ever,",
                    SHORTVENDORCOMMENT =
                        "test<br/><br/>Adrian<br/><br/>this is a test comment<br/><br/>Adrian<br/><br/>this is a test for the second time.<br/><br/>Adrian",
                    VENDORCOMMENT =
                        "test<br/><br/>Adrian<br/><br/>this is a test comment<br/><br/>Adrian<br/><br/>this is a test for the second time.<br/><br/>Adrian"
                },
                new Feedback
                {
                    COUNT = 4,
                    CUSTOMERCOMMENT = "As Above",
                    DATE = "17-Apr-2015",
                    DESCRIPTION = "Test",
                    FACEBOOKSHARELINK =
                        "http://www.facebook.com/sharer.php?u=http%3A%2F%2Fwww.feefo.com%2FGB%2Fen%2Freviews%2FExample-Supplier-Ltd%2F%3Fid%3D13%26servicefeedbackid%3D7445167",
                    FEEDBACKID = 7445167,
                    FurtherCommentsThread = new FurtherCommentsThread
                    {
                        POST = new List<Post>
                        {
                            new Post
                            {
                                DATE = "17-Apr-2015",
                                VENDORCOMMENT = "Test<br><br>Adrian"
                            }
                        }
                    },
                    HREVIEWDATE = new DateTime(2015, 04, 17, 09, 52, 13),
                    HREVIEWRATING = 5,
                    LINK = "http://www.examplesupplier.com/product_info.php?products_id=Test3OSCommerceOSCommerce",
                    PRODUCTCODE = "Test",
                    PRODUCTRATING = "++",
                    READMOREURL =
                        "http://www.feefo.com/GB/en/reviews/Example-Supplier-Ltd/?id=13&servicefeedbackid=7445167",
                    SERVICERATING = "++",
                    SHORTCUSTOMERCOMMENT = "As Above",
                    SHORTVENDORCOMMENT = "Test<br/><br/>Adrian",
                    VENDORCOMMENT = "Test<br/><br/>Adrian"
                }
            };
        }
    }
}
