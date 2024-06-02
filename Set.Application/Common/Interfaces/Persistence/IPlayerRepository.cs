using Set.Domain.PlayerAggregate;

namespace Set.Application.Common.Interfaces.Persistence;

public interface IPlayerRepository
{
    Player? GetPlayerByEmail(string email);
    void Add(Player player);
}