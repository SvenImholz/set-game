using Set.Domain.Common.Models;
using Set.Domain.DeckAggregate.ValueObjects;
using Set.Domain.GameAggregate.ValueObjects;
using Set.Domain.PlayerAggregate.ValueObjects;

namespace Set.Domain.GameAggregate;

public sealed class Game : AggregateRoot<GameId>
{
    Game(GameId gameId, DeckId deckId, PlayerId? playerId) : base(gameId)
    {
        DeckId = deckId;
        PlayerId = playerId;
    }

    public static Game Create(PlayerId playerId) =>
        new(
        GameId.CreateUnique(),
        DeckId.CreateUnique(),
        playerId
        );

    public new PlayerId? PlayerId { get; set; }
    public DeckId DeckId { get; }
}