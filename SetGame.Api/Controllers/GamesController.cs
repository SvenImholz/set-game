using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using SetGame.Application.Common.Interfaces.Persistence;
using SetGame.Application.Games.Commands.CreateGame;
using SetGame.Contracts.Games;
using SetGame.Domain.GameAggregate;
using SetGame.Domain.PlayerAggregate;

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
        Player player = playerRepository.GetPlayerById(playerId) ??
                        throw new Exception(
                        "Player not found");
        await Task.CompletedTask;
        List<Game> games = gameRepository.GetAllGamesFromPlayer(player.Id);

        return Ok(games);
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