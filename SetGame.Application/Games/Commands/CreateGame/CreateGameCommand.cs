using ErrorOr;

using MediatR;

using SetGame.Domain.GameAggregate;

namespace SetGame.Application.Games.Commands.CreateGame;

public record CreateGameCommand(
    Guid PlayerId
) : IRequest<ErrorOr<Game>>;