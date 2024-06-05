using SetGame.Domain.PlayerAggregate;

namespace SetGame.Application.Common.Interfaces.Persistence;

public interface IPlayerRepository
{
    Player? GetPlayerByEmail(string email);
    void Add(Player player);
}