using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SetGame.Application.Authentication.Commands.Register;
using SetGame.Application.Authentication.Queries.Login;
using SetGame.Contracts.Authentication;
using SetGame.Domain.Common.Errors;

namespace SetGame.Api.Controllers;

[Route("api/auth")]
[AllowAnonymous]
public class AuthenticationController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);

        var authResult = await sender.Send(command);

        return authResult.Match(
        result => Ok(mapper.Map<AuthenticationResponse>(result)),
        Problem);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = mapper.Map<LoginQuery>(request);

        var authResult = await sender.Send(query);

        if (authResult.IsError &&
            authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
            statusCode: StatusCodes.Status401Unauthorized,
            title: authResult.FirstError.Description);
        }

        return authResult.Match(
        result => Ok(mapper.Map<AuthenticationResponse>(result)),
        Problem);
    }
}