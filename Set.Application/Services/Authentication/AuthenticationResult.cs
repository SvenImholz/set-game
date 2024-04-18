using Set.Domain.Entities;

namespace Set.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);