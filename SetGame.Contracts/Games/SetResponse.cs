namespace SetGame.Contracts.Games;

public record SetResponse(
    Guid SetId,
    CardResponse[] Cards);