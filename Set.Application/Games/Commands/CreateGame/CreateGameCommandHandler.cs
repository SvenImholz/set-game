using ErrorOr;

using MediatR;

using Set.Domain.GameAggregate;

namespace Set.Application.Games.Commands.CreateGame;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, ErrorOr<Game>>
{
    public Task<ErrorOr<Game>> Handle(
        CreateGameCommand request,
        CancellationToken cancellationToken)
    {
        // Create game
        var game = Game.Create(request.PlayerId); 
        // Persist game
        
        // Return game
        return Task.FromResult<ErrorOr<Game>>(game);
    }
}