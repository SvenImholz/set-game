using SetGame.Application.Common.Interfaces.Persistence;
using SetGame.Domain.PlayerAggregate;

namespace SetGame.Infrastructure.Persistence;

public class PlayerRepository : IPlayerRepository
{
    private static readonly List<Player> Players = [];

    public Player? GetPlayerByEmail(string email)
    {
        return Players.SingleOrDefault(u => u.Email == email);
    }

    public Player? GetPlayerById(Guid playerId)
    {
        return Players.SingleOrDefault(u => u.Id.Value == playerId);
    }

    public void Add(Player player) { Players.Add(player); }
}