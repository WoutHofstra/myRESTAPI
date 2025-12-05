using Microsoft.EntityFrameworkCore;
using myRESTAPI.Infrastructure.Persistence;
using myRESTAPI.Infrastructure.Repositories;

namespace myRESTAPI.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITaskRepository, TaskRepository>();
            return services;
        }
    }
}

