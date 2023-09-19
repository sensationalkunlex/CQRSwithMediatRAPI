using MediatR;

namespace CQRSTest.CQRS
{
    public interface ISender
    {
        Task<object?> Send(object request, CancellationToken cancellationToken = default);
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}