using UpVote.Models;
using UpVote.Repositories.Base;

using System.Data.SqlClient;
using Dapper;

namespace UpVote.Repositories;

public class UserDiscussionDapperRepository : BaseSqlRepository
{
    public async Task<IEnumerable<int>> GetUsersIdByDiscussionIdAsync(int id) {
        var connection = new SqlConnection(connectionString);
        return await connection.QueryAsync<int>(@$"select [UserId] from UsersDiscussions as ud
                                                          where ud.[DiscussionId] = {id}");
    }
}