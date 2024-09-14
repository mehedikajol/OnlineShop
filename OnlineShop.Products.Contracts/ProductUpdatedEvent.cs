using NetCore.Essentials.Events;

namespace OnlineShop.Products.Contracts;
public record ProductUpdatedEvent(Guid Id, string Title, string Description, decimal Price) : IEvent;
