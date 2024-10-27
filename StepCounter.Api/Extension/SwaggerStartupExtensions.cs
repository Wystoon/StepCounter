namespace StepCounter.Api.Extension;

public static class SwaggerStartupExtensions
{
    public static void ConfigureSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
    }
    
    public static void UseSwaggerUiWithVersioning(this WebApplication app)
    {
        app.UseSwaggerUI(options =>
        {
            var versionDescriptions = app.DescribeApiVersions()
                .OrderBy(v => v.IsDeprecated)
                .ThenByDescending(v => v.ApiVersion);

            foreach (var groupName in versionDescriptions.Select(v => v.GroupName))
            {
                var url = $"/swagger/{groupName}/swagger.json";
                var name = groupName.ToUpperInvariant();
                options.SwaggerEndpoint(url, name);
            }

            options.EnableDeepLinking();
        });
    }
}