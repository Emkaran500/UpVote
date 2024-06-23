namespace UpVote.Repositories;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UpVote.Data;
using UpVote.Models;
using UpVote.Options;
using UpVote.Repositories.Base;

public class SectionEFRepository : ISectionRepository
{
        private readonly UpVoteDbContext dbContext;

    public async Task CreateAsync(Section? section)
    {
        if (section == null)
        {
            throw new ArgumentNullException("Section didn't arrive!");
        }

        section.CreationDate = DateTime.Now;
        await this.dbContext.Sections.AddAsync(section);
        this.dbContext.SaveChanges();
    }

    public async Task DeleteAsync(int? id)
    {
        var searchedSection = await this.dbContext.Sections.FirstOrDefaultAsync<Section>(section => section.Id == id);
        if (searchedSection != null)
        {
            this.dbContext.Sections.Remove(searchedSection);
            this.dbContext.SaveChanges();
        }
    }

    public async Task<IEnumerable<Section>?> GetAllAsync()
    {
        var sections = this.dbContext.Sections.TakeWhile(section => true);
        return sections;
    }

    public async Task<IEnumerable<Section>?> GetByIdAsync(int id)
    {
        var sections = this.dbContext.Sections.TakeWhile(section => section.Id == id);
        return sections;
    }

    public async Task<long> UpdateAsync(Section? section)
    {
        var searchedSection = await this.dbContext.Sections.FirstOrDefaultAsync<Section>(oldSection => oldSection.Id == section.Id);
        if (searchedSection != null)
        {
            searchedSection = section;
            this.dbContext.Sections.Update(searchedSection);
        }

        return this.dbContext.SaveChanges();
    }
}