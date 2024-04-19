using MediatR;
using Microsoft.AspNetCore.Mvc;
using Set.Application.Authentication.Commands.Register;
using Set.Application.Authentication.Common;
using Set.Application.Authentication.Queries.Login;
using Set.Contracts.Authentication;
using Set.Domain.Common.Errors;

namespace Set.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    readonly ISender _sender;

    public AuthenticationController(ISender sender) { _sender = sender; }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        
        var authResult = await _sender.Send(command);

        return authResult.Match(
        authResult => Ok(MapAuthResponse(authResult)),
        Problem);

    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(
            request.Email,
            request.Password);
        var authResult = await _sender.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

        return authResult.Match(
        authResult => Ok(MapAuthResponse(authResult)),
        Problem);
    }

    private AuthenticationResponse MapAuthResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
        authResult.User.Id,
        authResult.User.FirstName,
        authResult.User.LastName,
        authResult.User.Email,
        authResult.Token);
    }

}