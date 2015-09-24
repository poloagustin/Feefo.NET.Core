using System.Collections;
using System.Collections.Generic;

namespace Feefo
{
    public class QueryStringFactory : IQueryStringFactory
    {
        public string Create(string logon, FeedbackRequest feedbackRequest)
        {
            var query = $"?logon={logon}&json=true";

            if (feedbackRequest.VendorRef != null)
            {
                query += $"&vendorref={feedbackRequest.VendorRef}";
            }
            
            if (feedbackRequest.Since != Since.None)
            {
                var since = _sinceValueMap[feedbackRequest.Since];

                query += $"&since={since}";
            }

            if (feedbackRequest.Sort != null)
            {
                var sortBy = _sortByValueMap[feedbackRequest.Sort.SortBy];
                var order = feedbackRequest.Sort.Order == Order.Ascending ? "asc" : "desc";

                query += $"&sortby={sortBy}&order={order}";
            }

            return query;
        }

        private readonly IDictionary<SortBy, string> _sortByValueMap = new Dictionary<SortBy, string>()
        {
            { SortBy.ProductFeedback, "product_feedback" },
            { SortBy.Date, "date" },
            { SortBy.Description, "description" },
            { SortBy.Relevance, "relevance" },
            { SortBy.ServiceFeedback, "service_feedback" },
        };

        private readonly IDictionary<Since, string> _sinceValueMap = new Dictionary<Since, string>()
        {
            { Since.Week, "week" },
            { Since.Month, "month" },
            { Since.SixMonths, "6months" },
            { Since.Year, "year" }
        };
    }
}