using Set.Domain.Common.Models;

namespace Set.Domain.PlayerAggregate.ValueObjects;

public class PlayerId : ValueObject
{
    public Guid Value { get; }
    PlayerId(Guid value) => Value = value;
    public static PlayerId CreateUnique() => new (Guid.NewGuid());

    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static PlayerId Create(Guid playerId) => new (playerId);
}