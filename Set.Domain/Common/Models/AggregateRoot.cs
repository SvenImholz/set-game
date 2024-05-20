namespace Set.Domain.Common.Models;

public abstract class AggregateRoot<TId>(TId playerId) : Entity<TId>(playerId)
    where TId : notnull;