namespace SetGame.Contracts.Games;

public record GameResponse(
    Guid Id,
    Guid? PlayerId,
    Guid DeckId,
    List<SetResponse> Sets,
    string State,
    DateTime CreatedAt,
    DateTime UpdatedAt
);