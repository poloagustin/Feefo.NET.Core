using Feefo.Responses;

namespace Feefo
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