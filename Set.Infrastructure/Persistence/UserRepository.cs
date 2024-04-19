using Set.Application.Common.Interfaces.Persistence;
using Set.Domain.Entities;

namespace Set.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{

    readonly static List<User> _users = new();
    public User? GetUserByEmail(string email) { return _users.SingleOrDefault(u => u.Email == email); }
    public void Add(User user) { _users.Add(user); }
}