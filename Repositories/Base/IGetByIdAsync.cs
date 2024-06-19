namespace UpVote.Repositories.Base;

public interface IGetByIdAsync<TEntity>
{
    Task<IEnumerable<TEntity>?> GetByIdAsync(int id);
}