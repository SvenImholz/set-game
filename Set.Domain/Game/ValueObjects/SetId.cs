using Set.Domain.Common.Models;

namespace Set.Domain.Game.ValueObjects;

public sealed class SetId : ValueObject
{
    public Guid Value { get; }
    
    SetId(Guid value)
    {
        Value = value;
    }
    
    public static SetId CreateUnique()
    {
        return new SetId(Guid.NewGuid());
    }
    
    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}