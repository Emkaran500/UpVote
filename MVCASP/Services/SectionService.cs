namespace UpVote.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using UpVote.Models;
using UpVote.Repositories.Base;
using UpVote.Services.Base;

public class SectionService : ISectionService
{
    private readonly ISectionRepository sectionRepository;

    public SectionService(ISectionRepository sectionRepository)
    {
        this.sectionRepository = sectionRepository;
    }

    public async Task CreateNewSectionAsync(Section? newSection)
    {
        ArgumentNullException.ThrowIfNull(newSection);

        await this.sectionRepository.CreateAsync(newSection);
    }

    public async Task DeleteSectionAsync(int? id)
    {
        ArgumentNullException.ThrowIfNull(id);

        await this.sectionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Section>?> GetAllSectionsAsync()
    {
        return await this.sectionRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Section>?> GetSectionByIdAsync(int? id)
    {
        ArgumentNullException.ThrowIfNull(id);

        return await this.sectionRepository.GetByIdAsync(id.Value);
    }

    public async Task UpdateSectionAsync(Section? section)
    {
        ArgumentNullException.ThrowIfNull(section);

        await this.sectionRepository.UpdateAsync(section);
    }
}