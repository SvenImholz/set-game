using SetGame.Domain.PlayerAggregate;

namespace SetGame.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Player player);
}