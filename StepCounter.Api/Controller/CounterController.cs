using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using StepCounter.Core.Interface;
using StepCounter.Core.Model.Counter;
using StepCounter.Core.Model.Counter.DTO;

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

        return Created(new Uri($"{Request.Scheme}://{Request.Host}/v1/counter/{counter.Id}"), counter);
    }
    
    [HttpGet("{counterId:guid}")]
    [ProducesResponseType(typeof(Counter), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Counter>> GetCounter([Required] Guid counterId)
        => Ok(await counterService.GetCounterAsync(counterId));

    [HttpPut("{counterId:guid}")]
    [ProducesResponseType(typeof(Counter), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Counter>> UpdateCounter(
        [Required] Guid counterId,
        [Required] UpdateCounterRequest request)
        => Ok(await counterService.UpdateCounterAsync(counterId, request));
}