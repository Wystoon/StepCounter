using StepCounter.Core.Model.GlobalScore;

namespace StepCounter.Core.Interface;

public interface IGlobalScoreRepository
{
    Task<GlobalScore> GetGlobalScoreAsync();
}