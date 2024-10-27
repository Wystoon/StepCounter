using StepCounter.Core.Model.Team;
using StepCounter.Core.Model.Team.DTO;

namespace StepCounter.Core.Interface;

public interface ITeamService
{
    Task<Team> CreateTeamAsync();
    Task<Team> GetTeamAsync(Guid teamId);
    Task<Team> UpdateTeamAsync(Guid teamId, UpdateTeamRequest request);
    Task DeleteTeamAsync(Guid teamId);
}