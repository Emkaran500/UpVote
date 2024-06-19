namespace UpVote.Repositories.Base;

public interface IDeleteAsync
{
    Task DeleteAsync(int? id);
}