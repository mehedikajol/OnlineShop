using NetCore.Essentials.Events;

namespace OnlineShop.Products.Contracts;

public record ProductCreatedEvent(Guid Id, string Title, string Description, decimal Price) : IEvent;
