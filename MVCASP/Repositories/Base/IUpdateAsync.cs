using UpVote.Models;

namespace UpVote.Repositories.Base;

public interface IUpdateAsync<T>
{
    Task<long> UpdateAsync(T? entity);
}