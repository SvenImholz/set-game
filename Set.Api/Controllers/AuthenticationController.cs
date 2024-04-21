using MapsterMapper;
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
    readonly IMapper _mapper;
    
    public AuthenticationController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        
        var authResult = await _sender.Send(command);

        return authResult.Match(
        authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
        Problem);

    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        
        var authResult = await _sender.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

        return authResult.Match(
        authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
        Problem);
    }

}