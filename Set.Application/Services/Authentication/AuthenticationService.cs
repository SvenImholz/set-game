using Set.Application.Common.Interfaces.Authentication;
using Set.Application.Common.Interfaces.Persistence;
using Set.Domain.Entities;

namespace Set.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService {
    readonly IJwtTokenGenerator _jwtTokenGenerator;
    readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        // Validate 
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with email already exists.");
        }

        // Create user
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
        user,
        Token: token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Validate that the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with email does not exist.");
        }
        // Validate that the password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }
        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
        user,
        Token: token);
    }
}