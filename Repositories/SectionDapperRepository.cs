namespace UpVote.Repositories;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConfigurationApp.Options.Connections;
using Dapper;
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

    public async Task CreateAsync(Section? section)
    {
        using var connection = new SqlConnection(this.connectionString);
        var format = "yyyy-MM-dd";
        section.CreationDate = DateTime.Now;
        var stringDate = DateTime.Now.Date.ToString(format);

        await connection.ExecuteAsync($"Insert into Sections([Name], [CreationDate]) Values ('{section.Name ?? null}', '{stringDate}')");
    }

    public async Task DeleteAsync(int? id)
    {
        using var connection = new SqlConnection(this.connectionString);

        var sectionIds = await connection.QueryAsync<int>("Select [Id] From Sections");

        var containsId = sectionIds.Contains(id.Value);

        if (containsId)
        {
            await connection.ExecuteAsync($"Delete from Sections Where Sections.[Id] = {id}");
        }
    }

    public async Task<IEnumerable<Section>?> GetAllAsync()
    {
        using var connection = new SqlConnection(this.connectionString);

        return await connection.QueryAsync<Section>("Select * from Sections");
    }

    public async Task<IEnumerable<Section>?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(this.connectionString);

        return await connection.QueryAsync<Section>($"Select * from Sections Where Sections.[Id] = {id}");
    }

    public async Task<long> UpdateAsync(Section? section)
    {
        using var connection = new SqlConnection(this.connectionString);
        StringBuilder sql = new StringBuilder();

        ArgumentNullException.ThrowIfNull(section);

        sql.Append($"Update {section.GetType().Name}s ");

        var searchedSection = connection.QueryFirst<Section>($"Select * from Sections Where Sections.[Id] = {section?.Id ?? null}");

        if (searchedSection != null && searchedSection.Name != section.Name && !string.IsNullOrWhiteSpace(section.Name))
        {
            searchedSection.Name = section.Name;
            sql.Append($"Set [{nameof(section.Name)}] = '{section.Name}' ");
        }

        sql.Append($"Where [{nameof(section.Id)}] = {section.Id} ");

        System.Console.WriteLine(sql.ToString());

        return await connection.ExecuteAsync(sql.ToString());
    }
}