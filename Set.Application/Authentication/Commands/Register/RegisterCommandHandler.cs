using ErrorOr;
using MediatR;
using Set.Application.Authentication.Common;
using Set.Application.Common.Interfaces.Authentication;
using Set.Application.Common.Interfaces.Persistence;
using Set.Domain.Common.Errors;
using Set.Domain.PlayerAggregate;

namespace Set.Application.Authentication.Commands.Register;

public class
    RegisterCommandHandler : IRequestHandler<RegisterCommand,
    ErrorOr<AuthenticationResult>>
{
    readonly IJwtTokenGenerator _jwtTokenGenerator;
    readonly IPlayerRepository _playerRepository;

    public RegisterCommandHandler(
        IPlayerRepository playerRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _playerRepository = playerRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Validate 
        if (_playerRepository.GetPlayerByEmail(command.Email) is not null)
            return Errors.User.DuplicateEmail;

        // Create user
        var player = Player.Create(
        command.FirstName,
        command.LastName,
        command.Email,
        command.Password);


        _playerRepository.Add(player);

        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(player);

        return new AuthenticationResult(
        player,
        token);
    }
}