using Mapster;
using Set.Application.Games.Commands.CreateGame;

namespace Set.Api.Common.Mapping;

public class GameMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, CreateGameCommand>()
            .Map(dest => dest.PlayerId, src => src);
    }
}