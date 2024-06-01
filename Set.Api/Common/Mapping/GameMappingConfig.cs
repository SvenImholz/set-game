using Mapster;

using Set.Application.Games.Commands.CreateGame;
using Set.Contracts.Games;

namespace Set.Api.Common.Mapping;

public class GameMappingConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateGameRequest, CreateGameCommand>();
    }
}