namespace SetGame.Contracts.Games;

public record DeckResponse(
    Guid Id,
    List<CardResponse> Cards);