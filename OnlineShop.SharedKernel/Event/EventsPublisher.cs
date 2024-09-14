using NetCore.Essentials.Events;

namespace OnlineShop.SharedKernel.Event;

internal class EventsPublisher : IEventsPublisher
{
    private readonly IEventPublisher _publisher;

    public EventsPublisher(IEventPublisher publisher)
    {
        _publisher = publisher;
    }

    public void PublishAllEvents(IEnumerable<IEvent> events)
    {
        foreach (var @event in events)
        {
            _publisher.Publish(@event);
        }
    }
}