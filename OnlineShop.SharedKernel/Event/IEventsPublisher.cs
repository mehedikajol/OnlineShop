using NetCore.Essentials.Events;

namespace OnlineShop.SharedKernel.Event;

public interface IEventsPublisher
{
    void PublishAllEvents(IEnumerable<IEvent> events);
}
