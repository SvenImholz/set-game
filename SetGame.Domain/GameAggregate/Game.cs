using SetGame.Domain.Common.Enums;
using SetGame.Domain.Common.Models;
using SetGame.Domain.DeckAggregate.ValueObjects;
using SetGame.Domain.GameAggregate.Entities;
using SetGame.Domain.GameAggregate.ValueObjects;
using SetGame.Domain.PlayerAggregate.ValueObjects;

namespace SetGame.Domain.GameAggregate;

public sealed class Game : AggregateRoot<GameId>
{

    Game(GameId gameId, DeckId deckId, PlayerId playerId) : base(gameId)
    {
        DateTime now = DateTime.UtcNow;
        DeckId = deckId;
        PlayerId = playerId;
        Sets = new List<Set>();
        State = GameState.Started;
        CreatedAt = now;
        UpdatedAt = now;
    }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; set; }
    public string State { get; set; }
    public List<Set> Sets { get; set; }

    public PlayerId PlayerId { get; }
    public DeckId DeckId { get; }

    public static Game Create(PlayerId playerId)
    {
        return new Game(
        GameId.CreateUnique(),
        DeckId.CreateUnique(),
        playerId
        );
    }
}