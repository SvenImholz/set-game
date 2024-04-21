using Microsoft.AspNetCore.Mvc;

namespace Set.Api.Controllers;

[Route("api/games")]
public class GamesController : ApiController
{
    [HttpGet]
    public IActionResult ListGames()
    {
        return Ok(Array.Empty<string>());
    }
    
}