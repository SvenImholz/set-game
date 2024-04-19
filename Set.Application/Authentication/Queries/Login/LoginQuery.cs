using MediatR;
using ErrorOr;
using Set.Application.Authentication.Common;

namespace Set.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;