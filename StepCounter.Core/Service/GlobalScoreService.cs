using StepCounter.Core.Interface;

namespace StepCounter.Core.Service;

public class GlobalScoreService(IGlobalScoreRepository globalScoreRepository, ICounterRepository counterRepository)
    : IGlobalScoreService
{
    public async Task<int> GetGlobalStepCountAsync()
    {
        var globalScore = await globalScoreRepository.GetGlobalScoreAsync();
        var globalStepCounter = await counterRepository.GetCounterAsync(globalScore.CounterId) ??
                                throw new KeyNotFoundException($"Counter with id {globalScore.CounterId} not found");

        return globalStepCounter.StepCount;
    }
}