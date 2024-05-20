using Set.Domain.Player;

namespace Set.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Player player);
}