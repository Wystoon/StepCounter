namespace StepCounter.Core.Interface;

public interface IGlobalScoreService
{
    Task<int> GetGlobalStepCountAsync();
}