using Set.Domain.PlayerAggregate;

namespace Set.Contracts.Games;

public record CreateGameRequest(
    Guid? PlayerId
);