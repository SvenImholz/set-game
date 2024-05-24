using Set.Domain.Common.Models;

namespace Set.Domain.PlayerAggregate.ValueObjects;

public class PlayerId : ValueObject
{
    public Guid Value { get; }
    PlayerId(Guid value) => Value = value;
    public static PlayerId CreateUnique() => new PlayerId(Guid.NewGuid());

    override public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}