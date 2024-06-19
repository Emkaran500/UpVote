using UpVote.Models;

namespace UpVote.Repositories.Base;

public interface ICreateLogAsync
{
    Task CreateLogAsync(HttpContext httpContext, Log newLog);
}