using Mapster;

using SetGame.Application.Games.Commands.CreateGame;
using SetGame.Contracts.Games;
using SetGame.Domain.GameAggregate;

using Set=SetGame.Domain.GameAggregate.Entities.Set;

namespace SetGame.Api.Common.Mapping;

public class GameMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, CreateGameCommand>()
            .Map(member: dest => dest.PlayerId, source: src => src);

        config.NewConfig<Game, GameResponse>()
            .Map(member: dest => dest.Id, source: src => src.Id.Value)
            .Map(
            member: dest => dest.PlayerId,
            source: src =>
                src.PlayerId.Value)
            .Map(
            member: dest => dest.DeckId,
            source: src =>
                src.DeckId.Value)
            .Map(member: dest => dest, source: src => src);

        config.NewConfig<Set, SetResponse>()
            .Map(member: dest => dest.SetId, source: src => src.Id.Value)
            .Map(member: dest => dest.Cards, source: src => src.Cards);


    }
}