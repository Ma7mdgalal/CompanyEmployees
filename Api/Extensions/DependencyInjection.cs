using Application.Contracts;
using Application.Contracts.Services;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Logging;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ILoggerService, LoggerService>();
        }
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            });
        }
    }
}
