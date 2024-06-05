using ErrorOr;

using MediatR;

using SetGame.Application.Common.Interfaces.Persistence;
using SetGame.Domain.GameAggregate;
using SetGame.Domain.PlayerAggregate.ValueObjects;

namespace SetGame.Application.Games.Commands.CreateGame;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand,
    ErrorOr<Game>>
{
    private readonly IGameRepository _gameRepository;

    public CreateGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

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
        _gameRepository.Add(game);

        // Return game
        return game;
    }
}