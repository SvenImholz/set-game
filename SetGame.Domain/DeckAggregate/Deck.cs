using SetGame.Domain.Common.Enums;
using SetGame.Domain.Common.Models;
using SetGame.Domain.DeckAggregate.Entities;
using SetGame.Domain.DeckAggregate.ValueObjects;

namespace SetGame.Domain.DeckAggregate;

public sealed class Deck : AggregateRoot<DeckId>
{
    readonly List<Card> _cards;
    private Deck(DeckId deckId) : base(deckId)
    {
        _cards = new List<Card>();
        foreach (Color color in Enum.GetValues(typeof(Color)))
        {
            foreach (Fill fill in Enum.GetValues(typeof(Fill)))
            {
                foreach (Number number in Enum.GetValues(typeof(Number)))
                {
                    foreach (Shape shape in Enum.GetValues(typeof(Shape)))
                    {
                        _cards.Add(
                        Card.Create(
                        color,
                        fill,
                        number,
                        shape));
                    }
                }
            }
        }
    }

    public IReadOnlyList<Card> Cards => _cards.AsReadOnly();

    public static Deck Create()
    {
        return new Deck(DeckId.CreateUnique());
    }
}