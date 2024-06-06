namespace SetGame.Contracts.Games;

public record CardResponse(
    Guid Id,
    int Number,
    string Color,
    string Shape,
    string Fill);