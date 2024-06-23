using UpVote.Models;
using UpVote.Repositories.Base;
using UpVote.Services.Base;

namespace UpVote.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<IEnumerable<User>?> GetUserByIdAsync(int? id)
    {
        ArgumentNullException.ThrowIfNull(id);

        return await this.userRepository.GetByIdAsync(id.Value);
    }
}