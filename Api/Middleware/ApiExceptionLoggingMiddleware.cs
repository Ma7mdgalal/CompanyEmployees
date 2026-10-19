using System.Diagnostics;

namespace Api.Middleware
{
    public class ApiExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionLoggingMiddleware> _logger;

        public ApiExceptionLoggingMiddleware(
            RequestDelegate next,
            ILogger<ApiExceptionLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                sw.Stop();
                _logger.LogError(ex,
                    "HTTP {Method} {Path} failed after {Elapsed}ms",
                    context.Request.Method,
                    context.Request.Path,
                    sw.ElapsedMilliseconds);
                throw;
            }
        }
    }
}
