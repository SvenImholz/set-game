using Set.Domain.PlayerAggregate;

namespace Set.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Player player);
}