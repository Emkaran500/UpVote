namespace UpVote.Middlewares;

public class LoggingMiddleware : IMiddleware
{
    private readonly IConfiguration configuration;
    private readonly RequestDelegate next;

    public LoggingMiddleware(IConfiguration configuration, RequestDelegate next)
    {
        this.configuration = configuration;
        this.next = next;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        
    }
}