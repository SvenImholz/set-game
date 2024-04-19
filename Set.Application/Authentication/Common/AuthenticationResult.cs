using Set.Domain.Entities;

namespace Set.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);