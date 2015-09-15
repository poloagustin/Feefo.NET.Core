using System.Collections.Generic;

namespace Feefo.Responses
{
    public class FeedbackList
    {
        public List<Feedback> FEEDBACK { get; set; }

        public Summary SUMMARY { get; set; }
    }
}