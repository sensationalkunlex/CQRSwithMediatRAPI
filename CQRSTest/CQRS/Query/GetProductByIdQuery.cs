using CQRSTest.Domain;
using MediatR;

namespace CQRSTest.CQRS.Query
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
