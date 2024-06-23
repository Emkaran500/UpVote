using UpVote.Models;

namespace UpVote.Repositories.Base;

public interface IAddRequestBodyAsync
{
    Task AddRequestBodyAsync(HttpContext httpContext, Log newLog);
}