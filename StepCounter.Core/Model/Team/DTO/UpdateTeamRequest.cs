namespace StepCounter.Core.Model.Team.DTO;

public record UpdateTeamRequest(List<Guid> MembersCountersIds, Guid TeamCounterId);