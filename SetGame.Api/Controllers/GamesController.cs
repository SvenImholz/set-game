using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using SetGame.Application.Common.Interfaces.Persistence;
using SetGame.Application.Games.Commands.CreateGame;
using SetGame.Contracts.Games;

namespace SetGame.Api.Controllers;

[Route("api/players/{playerId:guid}/games")]
public class GamesController(
    IMapper mapper,
    ISender mediatorSender,
    IGameRepository
        gameRepository,
    IPlayerRepository playerRepository) :
    ApiController
{
    [HttpGet]
    public async Task<IActionResult> ListGames(Guid playerId)
    {
        return Ok(Array.Empty<string>());
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame(Guid playerId)
    {
        CreateGameCommand command = mapper.Map<CreateGameCommand>(playerId);
        var createGameResult = await mediatorSender.Send(command);

        return createGameResult.Match(
        onValue: game => Ok(mapper.Map<GameResponse>(game)),
        Problem);
    }
}