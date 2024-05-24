using Set.Domain.Common.Models;

namespace Set.Domain.DeckAggregate.ValueObjects;

public class CardId : ValueObject
{
    public Guid Value { get; }
    CardId(Guid value) => Value = value;
    public static CardId CreateUnique() => new CardId(Guid.NewGuid());
    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
}