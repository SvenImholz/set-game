using ErrorOr;

using MediatR;

using SetGame.Application.Authentication.Common;

namespace SetGame.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;