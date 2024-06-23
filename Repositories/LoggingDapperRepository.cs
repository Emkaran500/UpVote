namespace UpVote.Repositories;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UpVote.Models;
using UpVote.Options;
using UpVote.Repositories.Base;

public class LoggingDapperRepository : ILoggingRepository
{
    private readonly string connectionString;

    public LoggingDapperRepository(IOptionsSnapshot<MsSqlConnectionOptions> msSqlConnectionOptions)
    {
        this.connectionString = msSqlConnectionOptions.Value.ConnectionString;
    }

    public async Task AddEndTimeToLogAsync(ILoggingRepository loggingRepository, Log newLog)
    {
        newLog.EndDate = DateTime.Now;
    }

    public async Task AddLogToDbAsync(Log newLog)
    {
        using var connection = new SqlConnection(this.connectionString);

        await connection.ExecuteAsync($@"Insert into Logs([Url], 
                                                          [RequestBody], 
                                                          [ResponseBody], 
                                                          [CreationDate], 
                                                          [EndDate], 
                                                          [StatusCode], 
                                                          [HttpMethod]) 
                                                            Values ('{newLog.Url}', 
                                                                    '{newLog.RequestBody}',
                                                                    '{newLog.ResponseBody}',
                                                                    '{newLog.CreationDate.ToString()}',
                                                                    '{newLog.EndDate.ToString()}',
                                                                    '{newLog.StatusCode}',
                                                                    '{newLog.HttpMethod}')");
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

    public async Task AddStartTimeToLogAsync(Log newLog)
    {
        newLog.CreationDate = DateTime.Now;
    }

    public async Task CreateLogAsync(HttpContext httpContext, Log newLog)
    {
        newLog.Url = httpContext.Request.GetEncodedUrl();
        
        newLog.StatusCode = httpContext.Response.StatusCode;
        newLog.HttpMethod = httpContext.Request.Method;
    }
}