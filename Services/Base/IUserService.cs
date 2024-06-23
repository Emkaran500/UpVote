using UpVote.Models;

namespace UpVote.Services.Base;

public interface IUserService
{
    public Task<IEnumerable<User>?> GetUserByIdAsync(int? id);
}