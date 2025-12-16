using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using myRESTAPI.Infrastructure.DependencyInjection;
using myRESTAPI.Application.Services;
using myRESTAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<ITaskService, TaskService>();

var connectionString = "Data Source=/home/app.db";

builder.Services.AddDbContext<TaskDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

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
    var db = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    db.Database.Migrate();
}

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();

