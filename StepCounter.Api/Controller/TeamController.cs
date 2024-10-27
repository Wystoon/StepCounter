using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using StepCounter.Core.Interface;
using StepCounter.Core.Model.Team;
using StepCounter.Core.Model.Team.DTO;

namespace StepCounter.Api.Controller;

[ApiController]
[Route("v{version:apiVersion}/team")]
public class TeamController(ITeamService teamService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Team), StatusCodes.Status201Created)]
    public async Task<ActionResult<Team>> CreateTeam()
    {
        var team = await teamService.CreateTeamAsync();

        return Created(new Uri($"team/{team.Id.ToString()}"), team);
    }

    [HttpGet("{teamId:guid}")]
    [ProducesResponseType(typeof(Team), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Team>> GetTeam([Required] Guid teamId)
        => Ok(await teamService.GetTeamAsync(teamId));

    [HttpPut("{teamId:guid}")]
    [ProducesResponseType(typeof(Team), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Team>> UpdateTeam([Required] Guid teamId, [Required] UpdateTeamRequest request)
        => Ok(await teamService.UpdateTeamAsync(teamId, request));

    [HttpDelete("{teamId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Team>> DeleteTeam([Required] Guid teamId)
    {
        await teamService.DeleteTeamAsync(teamId);

        return NoContent();
    }
}