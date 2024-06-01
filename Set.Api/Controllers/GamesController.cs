using Microsoft.AspNetCore.Mvc;

using Set.Contracts.Games;

namespace Set.Api.Controllers;

[Route("api/games/")]
public class GamesController : ApiController
{
    [HttpGet]
    public IActionResult ListGames()
    {
        return Ok(Array.Empty<string>());
    }
    
    [HttpPost]
    public IActionResult CreateGame(CreateGameRequest request)
    {
        return Ok(request);
    }
    
}