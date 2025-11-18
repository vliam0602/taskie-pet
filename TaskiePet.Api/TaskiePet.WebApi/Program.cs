using Microsoft.EntityFrameworkCore;
using TaskiePet.Application.Common;
using TaskiePet.Application.Repositories.Abstraction;
using TaskiePet.Application.Services;
using TaskiePet.Application.Services.Abstraction;
using TaskiePet.Infrastructure.Database;
using TaskiePet.Infrastructure.Repositories;
using TaskiePet.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

// Bind AppConfiguration from configuration
var config = builder.Configuration.Get<AppConfiguration>();
builder.Configuration.Bind(config);
builder.Services.AddSingleton(config!);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(config!.ConnectionStrings.DefaultDb));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactClient",
        policy => policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Add repositories and services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDailyTaskRepository, DailyTaskRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDailyTaskService, DailyTaskService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.MapOpenApi();

app.MapGet("/", ctx =>
{
    ctx.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

// Using global exception middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowReactClient");

app.MapControllers();

app.MapHealthChecks("/healthz");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogInformation($"Connection string: {config!.ConnectionStrings.DefaultDb}");

    try
    {
        logger.LogInformation("Applying migrations...");
        db.Database.Migrate();
        logger.LogInformation("Migrations applied successfully");

        var canConnect = db.Database.CanConnect();
        logger.LogInformation($"Can connect to database: {canConnect}");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error applying migrations");
        throw;
    }
}

app.Run();