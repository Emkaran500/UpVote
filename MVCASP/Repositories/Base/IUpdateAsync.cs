using UpVote.Models;

namespace UpVote.Repositories.Base;

public interface IUpdateAsync<TEntity>
{
    Task UpdateAsync(int? id, TEntity? entity);
}