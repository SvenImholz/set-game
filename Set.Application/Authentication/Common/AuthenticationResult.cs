using Set.Domain.PlayerAggregate;

namespace Set.Application.Authentication.Common;

public record AuthenticationResult(
    Player Player,
    string Token);