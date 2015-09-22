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

            if (feedbackRequest.Since.HasValue)
            {
                var since = _sinceValueMap[feedbackRequest.Since.Value];

                query += $"&since={since}";
            }

            return query;
        }

        private readonly IDictionary<Since, string> _sinceValueMap = new Dictionary<Since, string>()
        {
            { Since.Week, "week" },
            { Since.Month, "month" },
            { Since.SixMonths, "6months" },
            { Since.Year, "year" } 
        };
    }
}