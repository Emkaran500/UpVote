namespace UpVote.Controllers;

using UpVote.Controllers.Base;
using UpVote.Repositories;

public class UserController : BaseController
{
    private readonly UserDapperRepository userSqlRepository = new UserDapperRepository();

    public async Task GetAllUsers() {

        await WriteViewAsync(null, "users");
    }
}