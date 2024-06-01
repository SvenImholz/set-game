using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Set.Application.Games.Commands.CreateGame;
using Set.Contracts.Games;

namespace Set.Api.Controllers;

[Route("api/games/")]
public class GamesController(IMapper mapper, ISender mediatorSender) : ApiController
{
    [HttpGet]
    public IActionResult ListGames()
    {
        return Ok(Array.Empty<string>());
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateGame(CreateGameRequest request)
    {
        var command = mapper.Map<CreateGameCommand>(request);
        var createGameResult = await mediatorSender.Send(command);
        return Ok(createGameResult);
    }
    
}