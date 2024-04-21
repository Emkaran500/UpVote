using UpVote.Models;
using UpVote.Repositories.Base;

using System.Data.SqlClient;
using Dapper;

namespace UpVote.Repositories;

public class DiscussionDapperRepository : BaseSqlRepository
{
    public async Task<IEnumerable<Discussion>> GetAllDiscussionsAsync() {
        var connection = new SqlConnection(connectionString);
        return await connection.QueryAsync<Discussion>("select * from Discussions");
    }

    public async Task<Discussion> GetDiscussionByIdAsync(int id) {
        var connection = new SqlConnection(connectionString);
        return await connection.QueryFirstAsync<Discussion>(@$"select * from Discussions as d
                                                    where d.[Id] = {id}");
    }
}