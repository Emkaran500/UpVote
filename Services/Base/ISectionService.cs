using UpVote.Models;

namespace UpVote.Services.Base
{
    public interface ISectionService
    {
        public Task CreateNewSectionAsync(Section? newSection);
        public Task UpdateSectionAsync(Section? section);
        public Task<IEnumerable<Section>?> GetAllSectionsAsync();
        public Task<IEnumerable<Section>?> GetSectionByIdAsync(int? id);
        public Task DeleteSectionAsync(int? id);
    }
}