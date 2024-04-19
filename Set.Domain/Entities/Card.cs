namespace Set.Domain.Entities;

public class Card(
    Color color,
    Shape shape,
    Fill fill,
    Number number)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Color Color { get; set; } = color;
    public Shape Shape { get; set; } = shape;
    public Fill Fill { get; set; } = fill;
    public Number Number { get; set; } = number;
}