namespace UpVote.Repositories.Base;

public interface ICreateAsync<TEntity>
{
    Task CreateAsync(TEntity? instance);
}