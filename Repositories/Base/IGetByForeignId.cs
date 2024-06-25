using System.Collections;

namespace UpVote.Repositories.Base;

public interface IGetByForeignIdAsync<T>
{
    Task<T?> GetByForeignIdAsync(int id, string foreignName);
}