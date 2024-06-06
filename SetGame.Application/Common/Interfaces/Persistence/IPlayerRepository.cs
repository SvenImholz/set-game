using SetGame.Domain.PlayerAggregate;

namespace SetGame.Application.Common.Interfaces.Persistence;

public interface IPlayerRepository
{
    Player? GetPlayerByEmail(string email);
    Player? GetPlayerById(Guid playerId);
    void Add(Player player);
}