using Set.Domain.Common.Models;
using Set.Domain.Deck.Entities;
using Set.Domain.Deck.ValueObjects;

namespace Set.Domain.Deck;

public sealed class Deck : AggregateRoot<DeckId>
{
    readonly List<Card> _cards;
    private Deck(DeckId deckPlayerId) : base(deckPlayerId)
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

    public static Deck Create() => new(DeckId.CreateUnique());

    public IReadOnlyList<Card> Cards => _cards.AsReadOnly();
}