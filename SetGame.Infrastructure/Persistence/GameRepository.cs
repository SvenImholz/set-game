using SetGame.Application.Common.Interfaces.Persistence;
using SetGame.Domain.GameAggregate;

namespace SetGame.Infrastructure.Persistence;

public class GameRepository : IGameRepository
{
    private readonly List<Game> _games = [];
    public void Add(Game game) { _games.Add(game); }
}