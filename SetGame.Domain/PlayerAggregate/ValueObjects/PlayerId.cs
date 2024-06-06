using SetGame.Domain.Common.Models;

namespace SetGame.Domain.PlayerAggregate.ValueObjects;

public class PlayerId : ValueObject
{
    PlayerId(Guid value) => Value = value;
    public Guid Value { get; }
    public static PlayerId CreateUnique()
    {
        return new PlayerId(Guid.NewGuid());
    }

    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static PlayerId Create(Guid playerId)
    {
        return new PlayerId(playerId);
    }
}