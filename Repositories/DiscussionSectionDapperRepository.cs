using UpVote.Models;
using UpVote.Repositories.Base;

using System.Data.SqlClient;
using Dapper;

namespace UpVote.Repositories;

public class DiscussionSectionDapperRepository : BaseSqlRepository
{
    public async Task<IEnumerable<int>> GetDiscussionsIdBySectionIdAsync(int id) {
        var connection = new SqlConnection(connectionString);
        return await connection.QueryAsync<int>(@$"select [DiscussionId] from DiscussionsSections as ds
                                                          where ds.[SectionId] = {id}");
    }
}