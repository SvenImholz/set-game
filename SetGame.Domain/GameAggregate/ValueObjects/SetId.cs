using SetGame.Domain.Common.Models;

namespace SetGame.Domain.GameAggregate.ValueObjects;

public sealed class SetId : ValueObject
{

    SetId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public static SetId CreateUnique()
    {
        return new SetId(Guid.NewGuid());
    }

    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}