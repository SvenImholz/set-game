using SetGame.Domain.Common.Models;
using SetGame.Domain.DeckAggregate.ValueObjects;
using SetGame.Domain.GameAggregate.ValueObjects;

namespace SetGame.Domain.GameAggregate.Entities;

public sealed class Set : Entity<SetId>
{
    public Set(
        SetId setId,
        CardId c1,
        CardId c2,
        CardId c3) : base(setId)
    {
        if (IsSet([c1, c2, c3]))
        {
            Cards = [c1, c2, c3];
        }
        else
        {
            throw new ArgumentException("Cards do not form a set.");
        }
    }
    public CardId[] Cards { get; }

    private static bool IsSet(CardId[] set)
    {
        throw new NotImplementedException();
        // Todo: Implement this method
    }
}