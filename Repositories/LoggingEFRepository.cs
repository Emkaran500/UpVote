using System.Text;
using Microsoft.AspNetCore.Http.Extensions;
using UpVote.Data;
using UpVote.Models;
using UpVote.Repositories.Base;

namespace UpVote.Repositories;

public class LoggingEFRepository : ILoggingRepository
{
    private readonly UpVoteDbContext dbContext;

    public async Task AddEndTimeToLogAsync(ILoggingRepository loggingRepository, Log newLog)
    {
        newLog.EndDate = DateTime.Now;
    }

    public async Task AddLogToDbAsync(Log newLog)
    {
        await this.dbContext.Logs.AddAsync(newLog);
    }

    public async Task AddStartTimeToLogAsync(Log newLog)
    {
        newLog.CreationDate = DateTime.Now;
    }

    public async Task AddRequestBodyAsync(HttpContext httpContext, Log newLog)
    {
        var reqBody = await new StreamReader(httpContext.Request.Body, Encoding.Default).ReadToEndAsync();
        newLog.RequestBody = reqBody;
    }

    public async Task AddResponseBodyAsync(HttpContext httpContext, Log newLog)
    {
        var originalBodyStream = httpContext.Response.Body;
        using (var responseBody = new MemoryStream())
        {
            httpContext.Response.Body = responseBody;
            var resBody = await new StreamReader(httpContext.Response.Body, Encoding.Default).ReadToEndAsync();
            newLog.ResponseBody = resBody;
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }

    public async Task CreateLogAsync(HttpContext httpContext, Log newLog)
    {
        newLog.Url = httpContext.Request.GetEncodedUrl();
        
        newLog.StatusCode = httpContext.Response.StatusCode;
        newLog.HttpMethod = httpContext.Request.Method;
    }
}