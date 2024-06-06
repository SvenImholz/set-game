using SetGame.Application.Common.Interfaces.Persistence;
using SetGame.Domain.GameAggregate;
using SetGame.Domain.PlayerAggregate.ValueObjects;

namespace SetGame.Infrastructure.Persistence;

public class GameRepository : IGameRepository
{
    private readonly List<Game> _games = [];
    public void Add(Game game) { _games.Add(game); }
    public List<Game> GetAllGamesFromPlayer(PlayerId playerId)
    {
        return _games.Where(
            g => g.PlayerId == playerId)
            .ToList();
    }
}