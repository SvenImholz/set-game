using ErrorOr;
using MediatR;
using Set.Application.Authentication.Common;

namespace Set.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
