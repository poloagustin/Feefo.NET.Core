namespace Feefo
{
    public interface IQueryStringFactory
    {
        string Create(string logon, FeedbackRequest feedbackRequest);
    }
}