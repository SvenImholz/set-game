using Set.Domain.DeckAggregate.Entities;

namespace Set.Contracts.Games;

public record GameResponse(
    Guid Id,
    PlayerResponse? Player,
    DeckResponse Deck,
    List<SetResponse> Sets,
    string State,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record PlayerResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email);

public record DeckResponse(
    Guid Id,
    List<CardResponse> Cards);

public record SetResponse(
    List<CardResponse> Cards);

public record CardResponse(
    Guid Id,
    int Number,
    string Color,
    string Shape,
    string Fill);