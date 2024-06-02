using ErrorOr;
using MediatR;
using Set.Domain.GameAggregate;
using Set.Domain.PlayerAggregate.ValueObjects;

namespace Set.Application.Games.Commands.CreateGame;

public record CreateGameCommand(
    Guid PlayerId
) : IRequest<ErrorOr<Game>>;