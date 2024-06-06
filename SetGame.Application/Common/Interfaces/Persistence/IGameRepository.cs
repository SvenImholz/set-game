using SetGame.Domain.GameAggregate;
using SetGame.Domain.PlayerAggregate.ValueObjects;

namespace SetGame.Application.Common.Interfaces.Persistence;

public interface IGameRepository
{
    void Add(Game game);
    public List<Game> GetAllGamesFromPlayer(PlayerId playerId);
}