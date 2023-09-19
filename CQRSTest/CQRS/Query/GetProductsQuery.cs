using CQRSTest.Domain;
using MediatR;

namespace CQRSTest.CQRS.Query
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;

}
