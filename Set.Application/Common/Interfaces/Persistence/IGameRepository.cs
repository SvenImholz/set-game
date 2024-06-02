using Set.Domain.GameAggregate;

namespace Set.Application.Common.Interfaces.Persistence;

public interface IGameRepository
{
    void Add(Game game);

}