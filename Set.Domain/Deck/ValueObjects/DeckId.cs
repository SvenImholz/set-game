using Set.Domain.Common.Models;

namespace Set.Domain.Deck.ValueObjects;

public sealed class DeckId : ValueObject
{
    public Guid Value { get; }
    DeckId(Guid value)
    {
        Value = value;
    }

    public static DeckId CreateUnique()
    {
        return new DeckId(Guid.NewGuid());
    }
    
    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}