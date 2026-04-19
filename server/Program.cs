using server.Contracts.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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