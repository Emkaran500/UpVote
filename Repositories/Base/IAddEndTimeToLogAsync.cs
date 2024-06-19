using UpVote.Models;

namespace UpVote.Repositories.Base;

public interface IAddEndTimeToLogAsync
{
    Task AddEndTimeToLogAsync(ILoggingRepository loggingRepository, Log newLog);
}