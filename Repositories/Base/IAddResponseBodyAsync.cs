using UpVote.Models;

namespace UpVote.Repositories.Base;

public interface IAddResponseBodyAsync
{
    Task AddResponseBodyAsync(HttpContext httpContext, Log newLog);
}