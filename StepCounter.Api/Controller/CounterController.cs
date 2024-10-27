using Microsoft.AspNetCore.Mvc;
using StepCounter.Core.Interface;
using StepCounter.Core.Model.Counter;

namespace StepCounter.Api.Controller;

[ApiController]
[Route("v{version:apiVersion}/counter")]
public class CounterController(ICounterService counterService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Counter), StatusCodes.Status201Created)]
    public async Task<ActionResult<Counter>> CreateCounter()
    {
        var counter = await counterService.CreateCounterAsync();

        return Created(new Uri($"counter/{counter.Id.ToString()}"), counter);
    }
}