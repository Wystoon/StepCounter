using Microsoft.EntityFrameworkCore;
using StepCounter.Core.Interface;
using StepCounter.Core.Model.GlobalScore;
using StepCounter.Infrastructure.PersistenceContext;

namespace StepCounter.Infrastructure.Repository;

public class GlobalScoreRepository(AppDbContext context) : IGlobalScoreRepository
{
    public async Task<GlobalScore> GetGlobalScoreAsync()
        => await context.GlobalScores.SingleAsync();
}