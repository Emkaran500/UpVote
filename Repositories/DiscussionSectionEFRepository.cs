using System.Collections;
using UpVote.Data;
using UpVote.Models;
using UpVote.Repositories.Base;

namespace UpVote.Repositories;

public class DiscussionSectionEFRepository : IDiscussionSectionRepository<IEnumerable>
{
    private readonly UpVoteDbContext dbContext;

    public DiscussionSectionEFRepository(UpVoteDbContext context)
    {
        this.dbContext = context;
    }
    public async Task<IEnumerable> GetByForeignIdAsync(int id, string foreignName)
    {
        IEnumerable<DiscussionSection> discussionSection;
        if (foreignName == nameof(Discussion))
        {
            discussionSection = this.dbContext.DiscussionsSections.AsEnumerable().Where(discussionSection => discussionSection.Discussion.Id == id);
            List<Discussion> discussions = new List<Discussion>();
            foreach (var discussion in discussionSection)
            {
                discussions.Add(this.dbContext.Discussions.First(oldDiscussion => oldDiscussion.Id == discussion.Id));
            }
            return discussions.AsEnumerable();
        }
        else if (foreignName == nameof(Section))
        {
            discussionSection = this.dbContext.DiscussionsSections.AsEnumerable().Where(discussionSection => discussionSection.Section.Id == id);
            List<Section> sections = new List<Section>();
            foreach (var section in discussionSection)
            {
                sections.Add(this.dbContext.Sections.First(oldSection => oldSection.Id == section.Id));
            }
            return sections.AsEnumerable();
        }
        else
        {
            throw new Exception($"{foreignName} is incorrect!");
        }
    }
}