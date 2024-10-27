using Microsoft.AspNetCore.Mvc;
using StepCounter.Core.Interface;

namespace StepCounter.Api.Controller;

[ApiController]
[Route("v{version:apiVersion}/global-score")]
public class GlobalScoreController(IGlobalScoreService globalScoreService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> GetGlobalStepCount()
        => Ok(await globalScoreService.GetGlobalStepCountAsync());
}