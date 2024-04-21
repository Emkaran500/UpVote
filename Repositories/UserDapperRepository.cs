using UpVote.Models;
using UpVote.Repositories.Base;

using System.Data.SqlClient;
using Dapper;
using Upvote.Models;

namespace UpVote.Repositories;

public class UserDapperRepository : BaseSqlRepository
{
    public async Task<IEnumerable<User>> GetAllUsersAsync() {
        var connection = new SqlConnection(connectionString);
        return await connection.QueryAsync<User>("select * from Users");
    }

    public async Task<User> GetUserByIdAsync(int id) {
        var connection = new SqlConnection(connectionString);
        return await connection.QueryFirstOrDefaultAsync<User>(@$"select * from Users as u
                                                    where u.[Id] = {id}");
    }

    public async Task UpdateUserNameById(int id, string? name) {
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync($@"update Users as u set [Nickname] = {name}
                                         where u.[Id] = {id}");
    }

    public async Task CreateUser(string nickname, string password, DateTime creationDate)
    {
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync($@"insert into Users([Nickname], [Password], [CreationDate])
                                         values ({nickname}, {password}, {creationDate})");
    }

    public async Task DeleteUserById(int id)
    {
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync($"delete from Users as u where u.[Id] = {id}");
    }
}