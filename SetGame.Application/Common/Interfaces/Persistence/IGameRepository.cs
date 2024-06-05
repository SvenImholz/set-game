using SetGame.Domain.GameAggregate;

namespace SetGame.Application.Common.Interfaces.Persistence;

public interface IGameRepository
{
    void Add(Game game);
}