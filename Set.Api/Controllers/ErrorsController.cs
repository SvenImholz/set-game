using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Set.Api.Controllers;

[Route("/error")]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    public IActionResult Error()
    {
        Exception? exception =
            HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem();
    }
}