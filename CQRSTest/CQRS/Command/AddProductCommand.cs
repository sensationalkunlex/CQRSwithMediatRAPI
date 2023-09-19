using CQRSTest.Domain;
using MediatR;

namespace CQRSTest.CQRS.Command
{
//    public record AddProductCommand(Product Product) : IRequest;
    public record AddProductCommand(Product Product) : IRequest<Product>;
}