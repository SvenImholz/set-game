using Set.Domain.Common.Models;
using Set.Domain.DeckAggregate.ValueObjects;
using Set.Domain.GameAggregate.ValueObjects;
using Set.Domain.PlayerAggregate.ValueObjects;

namespace Set.Domain.GameAggregate;

public sealed class Game : AggregateRoot<GameId>
{
    Game(GameId gameId, DeckId deckId) : base(gameId)
    {
        DeckId = deckId;
    }

    public static Game Create() =>
        new(
        GameId.CreateUnique(),
        DeckId.CreateUnique()
        );

    public new PlayerId? PlayerId { get; set; }
    public DeckId DeckId { get; }
}