using Microsoft.AspNetCore.Mvc;
using Set.Api.Filters;
using Set.Application.Services.Authentication;
using Set.Contracts.Authentication;

namespace Set.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService) { _authenticationService = authenticationService; }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult =
            _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
        authResult.User.Id,
        authResult.User.FirstName,
        authResult.User.LastName,
        authResult.User.Email,
        authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);

        var response = new AuthenticationResponse(
        authResult.User.Id,
        authResult.User.FirstName,
        authResult.User.LastName,
        authResult.User.Email,
        authResult.Token);

        return Ok(response);
    }
}