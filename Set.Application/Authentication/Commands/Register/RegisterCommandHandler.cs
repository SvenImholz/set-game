using ErrorOr;
using MediatR;
using Set.Application.Authentication.Common;
using Set.Application.Common.Interfaces.Authentication;
using Set.Application.Common.Interfaces.Persistence;
using Set.Domain.Common.Errors;
using Set.Domain.Player;

namespace Set.Application.Authentication.Commands.Register;

public class
    RegisterCommandHandler : IRequestHandler<RegisterCommand,
    ErrorOr<AuthenticationResult>>
{
    readonly IJwtTokenGenerator _jwtTokenGenerator;
    readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Validate 
        if (_userRepository.GetUserByEmail(command.Email) is not null)
            return Errors.User.DuplicateEmail;

        // Create user
        var player = Player.Create(
        command.FirstName,
        command.LastName,
        command.Email,
        command.Password);


        _userRepository.Add(player);

        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(player);

        return new AuthenticationResult(
        player,
        token);
    }
}