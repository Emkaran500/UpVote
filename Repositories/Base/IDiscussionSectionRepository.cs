namespace UpVote.Repositories.Base;

using System.Collections;
using UpVote.Models;

public interface IDiscussionSectionRepository<IEnumerable> : IGetByForeignIdAsync<IEnumerable> {}