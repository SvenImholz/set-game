using SetGame.Domain.PlayerAggregate;

namespace SetGame.Application.Authentication.Common;

public record AuthenticationResult(
    Player Player,
    string Token);