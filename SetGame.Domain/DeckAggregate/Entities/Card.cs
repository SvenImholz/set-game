using SetGame.Domain.Common.Enums;
using SetGame.Domain.Common.Models;
using SetGame.Domain.DeckAggregate.ValueObjects;

namespace SetGame.Domain.DeckAggregate.Entities;

public sealed class Card
    : Entity<CardId>
{
    private Card(
        CardId cardId,
        Color color,
        Fill fill,
        Number number,
        Shape shape) : base
        (cardId)
    {
        Color = color;
        Fill = fill;
        Number = number;
        Shape = shape;
    }

    public Color Color { get; set; }
    public Shape Shape { get; set; }
    public Fill Fill { get; set; }
    public Number Number { get; set; }

    public static Card Create(
        Color color,
        Fill fill,
        Number number,
        Shape shape) =>
        new(
        CardId.CreateUnique(),
        color,
        fill,
        number,
        shape);
}