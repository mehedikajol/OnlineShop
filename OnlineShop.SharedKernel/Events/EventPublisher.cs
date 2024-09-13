using MediatR;
using OnlineShop.SharedKernel.Extensions;

namespace OnlineShop.SharedKernel.Events;

internal class EventPublisher : IEventPublisher
{
    private readonly IPublisher _publisher;

    public EventPublisher(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public void Publish<T>(T @event) where T : IEvent
    {
        Task.Run(() => _publisher.Publish(@event)).Forget();
    }
}