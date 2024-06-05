using SetGame.Domain.Common.Models;

namespace SetGame.Domain.DeckAggregate.ValueObjects;

public sealed class DeckId : ValueObject
{
    DeckId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public static DeckId CreateUnique()
    {
        return new DeckId(Guid.NewGuid());
    }

    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}