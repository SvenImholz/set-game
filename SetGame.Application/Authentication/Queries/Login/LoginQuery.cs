using ErrorOr;

using MediatR;

using SetGame.Application.Authentication.Common;

namespace SetGame.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;