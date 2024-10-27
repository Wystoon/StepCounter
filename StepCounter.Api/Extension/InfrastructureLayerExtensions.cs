using StepCounter.Core.Interface;
using StepCounter.Infrastructure.Repository;

namespace StepCounter.Api.Extension;

public static class InfrastructureLayerExtensions
{
    public static void AddInfrastructureLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICounterRepository, CounterRepository>();
        builder.Services.AddScoped<ITeamRepository, TeamRepository>();
        builder.Services.AddScoped<IGlobalScoreRepository, GlobalScoreRepository>();
    }
}