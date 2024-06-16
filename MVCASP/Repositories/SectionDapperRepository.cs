namespace UpVote.Repositories;

using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ConfigurationApp.Options.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UpVote.Models;
using UpVote.Repositories.Base;

public class SectionDapperRepository : ISectionRepository
{
    private readonly string connectionString;

    public SectionDapperRepository(IOptionsSnapshot<MsSqlConnectionOptions> msSqlConnectionOptions)
    {
        this.connectionString = msSqlConnectionOptions.Value.ConnectionString;
    }

    public Task CreateAsync(Section instance)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Section>?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Section>?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int? id, Section? section)
    {
        throw new NotImplementedException();
    }
}