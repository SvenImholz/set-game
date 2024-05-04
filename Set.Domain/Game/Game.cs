using Set.Domain.Game.ValueObjects;
using Set.Domain.Models;

namespace Set.Domain.Game;

public sealed class Game(GameId id) : AggregateRoot<GameId>(id)
{
    
}