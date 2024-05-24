using Set.Domain.Common.Models;

namespace Set.Domain.GameAggregate.ValueObjects;

public sealed class GameId : ValueObject
{
    public Guid Value { get; }

    GameId(Guid value)
    {
        Value = value;
    }

    public static GameId CreateUnique()
    {
        return new GameId(Guid.NewGuid());
    }
    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}