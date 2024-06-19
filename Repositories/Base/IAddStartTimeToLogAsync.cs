using UpVote.Models;

namespace UpVote.Repositories.Base;

public interface IAddStartTimeToLogAsync
{
    Task AddStartTimeToLogAsync(Log newLog);
}