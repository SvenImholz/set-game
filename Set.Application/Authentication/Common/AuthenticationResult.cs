using Set.Domain.Player;

namespace Set.Application.Authentication.Common;

public record AuthenticationResult(
    Player Player,
    string Token);