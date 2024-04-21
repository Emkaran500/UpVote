using UpVote.Models;
using UpVote.Repositories.Base;

using System.Data.SqlClient;
using Dapper;

namespace UpVote.Repositories;

public class SectionDapperRepository : BaseSqlRepository
{
    public async Task<IEnumerable<Section>> GetAllSectionsAsync() {
        var connection = new SqlConnection(connectionString);
        return await connection.QueryAsync<Section>("select * from Sections");
    }
}