namespace StepCounter.Core.Model.Team;

public record Team(Guid Id, List<Guid> MembersCountersIds, Guid TeamCounterId);