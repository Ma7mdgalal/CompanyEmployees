using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
namespace Api.Extensions
{
    public static class SeriLogExtensions
    {
        public static void ConfigureSeriLog(this IHostBuilder host)
        {
            host.UseSerilog((context, services, configuration) =>
            {
                configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithThreadId();
            });
        }
    }
}
