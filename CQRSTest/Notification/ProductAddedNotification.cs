using CQRSTest.Domain;
using MediatR;

namespace CQRSTest.Notification
{
    public record ProductAddedNotification(Product Product) : INotification;
}
