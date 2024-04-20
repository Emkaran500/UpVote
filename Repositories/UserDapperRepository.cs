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

    public async Task<IEnumerable<User>> GetUsersNamesAsync() {
        var connection = new SqlConnection(connectionString);
        return await connection.QueryAsync<User>("select [Name] from Users");
    }
}