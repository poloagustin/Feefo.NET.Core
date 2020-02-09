using Feefo.Core.Responses;

namespace Feefo.Core
{
    public class FeefoClientResponse
    {
        public FeefoClientResponse(FeedbackList feedbackList)
        {
            FeedbackList = feedbackList;
        }

        public FeedbackList FeedbackList { get; }
    }
}