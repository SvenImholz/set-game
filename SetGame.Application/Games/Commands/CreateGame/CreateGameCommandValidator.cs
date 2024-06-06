using FluentValidation;

namespace SetGame.Application.Games.Commands.CreateGame;

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(x => x.PlayerId)
            .NotEmpty();
    }
}