using Microsoft.EntityFrameworkCore;
using server.Contracts.Common;
using server.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FlowpilotDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/api/health", () =>
{
    var response = new HealthResponse
    {
        Status = "ok",
        Service = "flowpilot-api",
        UtcTime = DateTime.UtcNow
    };

    return Results.Ok(response);
})
.WithName("GetHealth")
.WithTags("Health");

app.Run();