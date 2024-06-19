using Microsoft.Extensions.Options;
using UpVote.Models;
using UpVote.Options;
using UpVote.Repositories.Base;

namespace UpVote.Middlewares;

public class LoggingMiddleware : IMiddleware
{
    private readonly ILoggingRepository loggingRepository;
    private LoggingSettings loggingSettings;

    public LoggingMiddleware(IOptionsMonitor<LoggingSettings> loggingMonitor, ILoggingRepository loggingRepository)
    {
        this.loggingSettings = loggingMonitor.CurrentValue;
        this.loggingRepository = loggingRepository;
    }
    
    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        if (loggingSettings.UseLogging == false)
        {
            await next.Invoke(httpContext);
            return;
        }

        var newLog = new Log();

        await this.loggingRepository.AddStartTimeToLogAsync(newLog);
        await next.Invoke(httpContext);
        await this.loggingRepository.CreateLogAsync(httpContext, newLog);
        await this.loggingRepository.AddEndTimeToLogAsync(loggingRepository, newLog);
        await this.loggingRepository.AddLogToDbAsync(newLog);
    }
}