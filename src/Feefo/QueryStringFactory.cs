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

            if (feedbackRequest.SortBy != SortBy.None)
            {
                var since = _sortByValueMap[feedbackRequest.SortBy];

                query += $"&sortby={since}";
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