using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Todo.Api.Core;

public class LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<LoggingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        _logger.LogInformation(message: $"Request: {httpContext.Request.Method} {httpContext.Request.Path}");
        var stopwatch = Stopwatch.StartNew();
        await _next(httpContext);
        stopwatch.Stop();
        _logger.LogInformation($"Response: {httpContext.Response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms");
    }
}
