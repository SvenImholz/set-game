using Set.Domain.Common.Enums;
using Set.Domain.Common.Models;
using Set.Domain.DeckAggregate.ValueObjects;

namespace Set.Domain.DeckAggregate.Entities;

public sealed class Card
   : Entity<CardId>
{
    private Card(
        CardId cardPlayerId,
        Color color,
        Fill fill,
        Number number,
        Shape shape) : base
        (cardPlayerId)
    {
        Color = color;
        Fill = fill;
        Number = number;
        Shape = shape;
    }
    
    public static Card Create(
        Color color,
        Fill fill,
        Number number,
        Shape shape) =>
        new(CardId.CreateUnique(), color, fill, number, shape);
    
    public Color Color { get; set; } 
    public Shape Shape { get; set; }
    public Fill Fill { get; set; } 
    public Number Number { get; set; }
}