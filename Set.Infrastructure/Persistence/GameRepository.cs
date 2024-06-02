using Set.Application.Common.Interfaces.Persistence;
using Set.Domain.GameAggregate;

namespace Set.Infrastructure.Persistence;

public class GameRepository : IGameRepository
{
readonly List<Game> _games = [];
    public void Add(Game game) { _games.Add(game);}
}