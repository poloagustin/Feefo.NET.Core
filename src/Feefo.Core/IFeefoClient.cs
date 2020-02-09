using System.Threading;
using System.Threading.Tasks;
using Feefo.Core.Requests;

namespace Feefo.Core
{
    public interface IFeefoClient
    {
        Task<FeefoClientResponse> GetFeedbackAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<FeefoClientResponse> GetFeedbackAsync(FeedbackRequest feedbackRequest, CancellationToken cancellationToken = default(CancellationToken));
    }
}