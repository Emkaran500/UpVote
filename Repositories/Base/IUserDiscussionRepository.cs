namespace UpVote.Repositories.Base;

using UpVote.Models;

public interface IUserDiscussionRepository<IEnumerable> : IGetByForeignIdAsync<IEnumerable> {}