using UpVote.Models;

namespace UpVote.Repositories.Base;

public interface IAddLogToDbAsync
{
    Task AddLogToDbAsync(Log newLog);
}