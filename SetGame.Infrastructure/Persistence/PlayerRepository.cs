using SetGame.Application.Common.Interfaces.Persistence;
using SetGame.Domain.PlayerAggregate;

namespace SetGame.Infrastructure.Persistence;

public class PlayerRepository : IPlayerRepository
{

    readonly static List<Player> _users = new();
    public Player? GetPlayerByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
    public void Add(Player player) { _users.Add(player); }
}