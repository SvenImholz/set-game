using SetGame.Domain.Common.Models;

namespace SetGame.Domain.GameAggregate.ValueObjects;

public sealed class GameId : ValueObject
{

    GameId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public static GameId CreateUnique()
    {
        return new GameId(Guid.NewGuid());
    }
    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}