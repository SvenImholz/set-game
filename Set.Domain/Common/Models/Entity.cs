namespace Set.Domain.Common.Models;

public abstract class Entity<TId>(TId playerId): IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId PlayerId { get; } = playerId;

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    override public bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && PlayerId.Equals(entity.PlayerId);
    }
    
    override public int GetHashCode() => PlayerId.GetHashCode();

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }
}