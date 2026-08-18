using System.Diagnostics;

namespace API.Middleware
{
    public class CorrelationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HeaderName = "X-Trace-Id";

        public CorrelationMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(HeaderName, out var traceId))
            {
                traceId = Activity.Current?.Id ?? Guid.NewGuid().ToString("N");
                context.Request.Headers[HeaderName] = traceId;
            }

            context.Response.Headers[HeaderName] = traceId;
            using var activity = new Activity("HttpRequest");
            activity.SetIdFormat(ActivityIdFormat.W3C);
            activity.Start();
            activity.AddTag("traceId", traceId.ToString());
            try
            {
                await _next(context);
            }
            finally
            {
                activity.Stop();
            }
        }
    }
}
