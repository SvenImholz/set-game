using Set.Domain.Cards.CardProperties;

namespace Set.Domain.Cards;

public class Card(int id, Color color, Shape shape, Fill fill, Number number)
{
    public int Id { get; set; } = id;
    public Color Color { get; set; } = color;
    public Shape Shape { get; set; } = shape;
    public Fill Fill { get; set; } = fill;
    public Number Number { get; set; } = number;
}