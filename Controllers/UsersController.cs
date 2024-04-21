namespace UpVote.Controllers;

using UpVote.Controllers.Base;
using UpVote.Repositories;
using UpVote.HttpAttributes;
using Upvote.Models;
using System.Net.Sockets;

public class UsersController : BaseController
{
    private readonly UserDapperRepository userSqlRepository = new UserDapperRepository();

    [HttpGet(ActionName = "GetAll")]
    public async Task GetAllUsers() {
        var users = await this.userSqlRepository.GetAllUsersAsync();

        if(users is not null && users.Any()) {
            List<KeyValuePair<string?, object>> userInfoPairs = new List<KeyValuePair<string?, object>>();
            foreach (var user in users)
            {
                userInfoPairs.Add(new KeyValuePair<string?, object>(user.Id.ToString(), user));
            }
            Dictionary<string?, object> usersDictionary = new Dictionary<string?, object>(userInfoPairs);
            await WriteViewAsync(users.FirstOrDefault(), usersDictionary, "index", "users");
        }
        else {
            await new ErrorController().NotFound(nameof(users));
        }
    }

    [HttpPut(ActionName = "Update")]
    public async Task UpdateUserNickname(int id, string? name)
    {
        if (await this.userSqlRepository.GetUserByIdAsync(id) != null)
        {
            await this.userSqlRepository.UpdateUserNameById(id, name);
        }
        else {
            await new ErrorController().NotFound($"User Id: {id}");
        }
    }

    [HttpPost(ActionName = "Create")]
    public async Task CreateUser(string? nickname, string? password, DateTime? creationDate)
    {
        if (!string.IsNullOrWhiteSpace(nickname)
         && !string.IsNullOrWhiteSpace(password)
         && creationDate is not null)
        {
            this.userSqlRepository.CreateUser(nickname, password, creationDate.Value);
        }
    }

    [HttpDelete(ActionName = "Delete")]
    public async Task DeleteUser(int id)
    {
        if (await this.userSqlRepository.GetUserByIdAsync(id) != null)
        {
            await this.userSqlRepository.DeleteUserById(id);
        }
    }
}