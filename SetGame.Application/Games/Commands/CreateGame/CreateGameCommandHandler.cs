using ErrorOr;

using MediatR;

using SetGame.Application.Common.Interfaces.Persistence;
using SetGame.Domain.GameAggregate;
using SetGame.Domain.PlayerAggregate.ValueObjects;

namespace SetGame.Application.Games.Commands.CreateGame;

public class CreateGameCommandHandler(IGameRepository gameRepository)
    : IRequestHandler<CreateGameCommand,
        ErrorOr<Game>>
{

    public async Task<ErrorOr<Game>> Handle(
        CreateGameCommand request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Create game
        Game game = Game.Create(
        playerId: PlayerId.Create(request.PlayerId)
        );
        // Persist game
        gameRepository.Add(game);

        // Return game
        return game;
    }
}