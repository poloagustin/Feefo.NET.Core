using Feefo.Core.Requests;

namespace Feefo.Core
{
    public interface IQueryStringFactory
    {
        string Create(string logon, FeedbackRequest feedbackRequest);
    }
}