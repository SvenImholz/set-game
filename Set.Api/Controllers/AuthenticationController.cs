using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Set.Application.Authentication.Commands.Register;
using Set.Application.Authentication.Common;
using Set.Application.Authentication.Queries.Login;
using Set.Contracts.Authentication;
using Set.Domain.Common.Errors;

namespace Set.Api.Controllers;

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
        authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
        Problem);

    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = mapper.Map<LoginQuery>(request);
        
        var authResult = await sender.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

        return authResult.Match(
        authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
        Problem);
    }

}