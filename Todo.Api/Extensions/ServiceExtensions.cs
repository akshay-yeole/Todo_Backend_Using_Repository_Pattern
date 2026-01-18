using Microsoft.EntityFrameworkCore;
using Todo.Contracts;
using Todo.Entities;
using Todo.Repository;

namespace Todo.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =configuration.GetConnectionString(name: "Default");
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
