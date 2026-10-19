using Api.Extensions;
using Api.Middleware;
using Application.Configuration;
using Infrastructure.Configuration;
using Serilog;
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting web host");
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // ✅ Replace default logging with Serilog
    builder.Host.ConfigureSeriLog();
    builder.Services.AddControllers();
    builder.Services.ConfigureCors();

    // DEPENDENCY INJECTION
    builder.Services.AddDependencyInjection();
    builder.Services.ConfigureApplication();
    builder.Services.ConfigureInfrastructure();

    // DbContext
    builder.Services.ConfigureDbContext(builder.Configuration);

    var app = builder.Build();

    app.UseSerilogRequestLogging(options =>
    {
        options.MessageTemplate =
            "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000}ms";
    });

    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();
    app.UseCors("CorsPolicy");
    app.UseMiddleware<ApiExceptionLoggingMiddleware>();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}
