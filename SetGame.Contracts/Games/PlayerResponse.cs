namespace SetGame.Contracts.Games;

public record PlayerResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email
);