using System.Diagnostics;

namespace API.Middlewares
{
    public class ProfilingMiddleware
    {
        private readonly ILogger<ProfilingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ProfilingMiddleware(ILogger<ProfilingMiddleware> logger, RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            _logger.LogInformation($"Request {context.Request.Path} took {stopwatch.ElapsedMilliseconds}MS " );

        }

    }
}
