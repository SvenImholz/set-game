using ErrorOr;

using MediatR;

using SetGame.Application.Authentication.Common;
using SetGame.Application.Common.Interfaces.Authentication;
using SetGame.Application.Common.Interfaces.Persistence;
using SetGame.Domain.Common.Errors;

namespace SetGame.Application.Authentication.Queries.Login;

public class
    LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    readonly IJwtTokenGenerator _jwtTokenGenerator;
    readonly IPlayerRepository _playerRepository;

    public LoginQueryHandler(
        IPlayerRepository playerRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _playerRepository = playerRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        LoginQuery query,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Validate that the player exists
        if (_playerRepository.GetPlayerByEmail(query.Email) is not {} player)
            return Errors.Authentication.InvalidCredentials;

        // Validate that the password is correct
        if (player.Password != query.Password)
            return Errors.Authentication.InvalidCredentials;

        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(player);

        return new AuthenticationResult(
        player,
        token);
    }
}