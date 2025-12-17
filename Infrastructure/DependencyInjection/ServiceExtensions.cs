using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myRESTAPI.Infrastructure.Persistence;
using myRESTAPI.Infrastructure.Repositories;

namespace myRESTAPI.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? configuration["DefaultConnection"];

            services.AddDbContext<TaskDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
