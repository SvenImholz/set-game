using Set.Application.Common.Interfaces.Persistence;
using Set.Domain.PlayerAggregate;

namespace Set.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{

    readonly static List<Player> _users = new();
    public Player? GetUserByEmail(string email) { return _users.SingleOrDefault(u => u.Email == email); }
    public void Add(Player player) { _users.Add(player); }
}