﻿namespace OnlineShop.Domain.Entities.Base;

public abstract class Entity : IEntity<Guid>
{
    public Guid Id { get; set; }

    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}