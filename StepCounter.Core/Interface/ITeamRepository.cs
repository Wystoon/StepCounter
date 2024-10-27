using StepCounter.Core.Model.Team;

namespace StepCounter.Core.Interface;

public interface ITeamRepository
{
    Task<Team> CreateTeamAsync(Team team);
    Task<Team?> GetTeamAsync(Guid teamId);
    Task<Team> UpdateTeamAsync(Team team);
    Task DeleteTeamAsync(Team team);
}