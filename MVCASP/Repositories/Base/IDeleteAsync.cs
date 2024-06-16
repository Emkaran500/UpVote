namespace UpVote.Repositories.Base;

public interface IDeleteAsync<TEntity>
{
    Task DeleteAsync(int? id);
}