using Set.Domain.PlayerAggregate;

namespace Set.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Player? GetUserByEmail(string email);
    void Add(Player player);
}