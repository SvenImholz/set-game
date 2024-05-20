using Mapster;
using Set.Application.Authentication.Commands.Register;
using Set.Application.Authentication.Common;
using Set.Application.Authentication.Queries.Login;
using Set.Contracts.Authentication;

namespace Set.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.Player);
    }
}