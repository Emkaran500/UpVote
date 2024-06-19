using UpVote.Models;

namespace UpVote.Repositories.Base;

public interface ILoggingRepository : ICreateLogAsync,
                                      IAddStartTimeToLogAsync,
                                      IAddEndTimeToLogAsync,
                                      IAddLogToDbAsync {}