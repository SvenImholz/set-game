using Set.Domain.Common.Models;
using Set.Domain.Deck.ValueObjects;
using Set.Domain.Game.ValueObjects;
using Set.Domain.Player.ValueObjects;

namespace Set.Domain.Game;

public sealed class Game : AggregateRoot<GameId>
{
    Game(GameId gameId) : base(gameId)
    {
    }

    public static Game Create() =>
        new(GameId.CreateUnique());

    public DeckId DeckId { get; set; }
    public PlayerId PlayerId { get; set; }
}