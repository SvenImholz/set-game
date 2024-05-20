using MediatR;
using ErrorOr;
using Set.Application.Authentication.Common;
using Set.Application.Common.Interfaces.Authentication;
using Set.Application.Common.Interfaces.Persistence;
using Set.Domain.Common.Errors;

namespace Set.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    readonly IJwtTokenGenerator _jwtTokenGenerator;
    readonly IUserRepository _userRepository;
    
    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Validate that the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not {} user)
            return Errors.Authentication.InvalidCredentials;

        // Validate that the password is correct
        if (user.Password != query.Password)
            return Errors.Authentication.InvalidCredentials;
        
        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
        user,
        token);
    }
}