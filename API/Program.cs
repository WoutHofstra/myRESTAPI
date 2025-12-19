using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using myRESTAPI.Application.Services;
using myRESTAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using myRESTAPI.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITaskService, TaskService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? builder.Configuration["DefaultConnection"];

var helloMessage = builder.Configuration.GetConnectionString("TEST_STRING");

builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    try
    {
        var db = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
        db.Database.Migrate();

        logger.LogInformation($"{helloMessage} Database migration completed successfully.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Database migration failed. Application will continue to run.");
    }
}

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();

