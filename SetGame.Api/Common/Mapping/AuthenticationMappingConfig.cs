using Mapster;

using SetGame.Application.Authentication.Commands.Register;
using SetGame.Application.Authentication.Common;
using SetGame.Application.Authentication.Queries.Login;
using SetGame.Contracts.Authentication;

namespace SetGame.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(member: dest => dest, source: src => src.Player.Id.Value);
    }
}