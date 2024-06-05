using SetGame.Domain.Common.Models;

namespace SetGame.Domain.DeckAggregate.ValueObjects;

public class CardId : ValueObject
{
    CardId(Guid value) => Value = value;
    public Guid Value { get; }
    public static CardId CreateUnique() => new CardId(Guid.NewGuid());
    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}