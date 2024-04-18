using Set.Domain.Entities;

namespace Set.Application.Common.Interfaces.Persistence;

public interface IUserRepository {
    User? GetUserByEmail(string email);
    void Add(User user);
}