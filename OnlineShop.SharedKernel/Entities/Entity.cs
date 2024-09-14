using NetCore.Essentials.Entities;
using NetCore.Essentials.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.SharedKernel.Entities;

public abstract class Entity : IEntity<Guid>, IHaveDomainEvents
{
    public Guid Id { get; protected set; }

    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Events
    private List<IEvent> _events = new List<IEvent>();
    [NotMapped]
    public IReadOnlyCollection<IEvent> DomainEvents => _events;

    public void ClearDoaminEvents() => _events.Clear();

    protected void AddDomainEvent(IEvent domainEvent) => _events.Add(domainEvent);
}
