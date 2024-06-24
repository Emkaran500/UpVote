namespace UpVote.Repositories.Base;

public interface IGetByForeignIdAsync<TEntity>
{
    Task<IEnumerable<TEntity>?> GetByForeignIdAsync(int id, string foreignName);
}