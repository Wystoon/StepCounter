using Microsoft.EntityFrameworkCore;
using StepCounter.Api.Extension;
using StepCounter.Infrastructure.PersistenceContext;

var builder = WebApplication.CreateBuilder(args);

builder.AddGeneralServices();
builder.AddApiLayer();
builder.AddInfrastructureLayer();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("DataSource=:memory:"));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.OpenConnection();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();
app.UseSwaggerUiWithVersioning();

app.Run();