namespace UpVote.Controllers;

using UpVote.Controllers.Base;
using UpVote.Repositories;
using UpVote.HttpAttributes;
using Upvote.Models;
using UpVote.Models;

public class SectionsController : BaseController
{
    private readonly SectionDapperRepository sectionSqlRepository = new SectionDapperRepository();
    private readonly DiscussionSectionDapperRepository discussionSectionSqlRepository = new DiscussionSectionDapperRepository();
    private readonly DiscussionDapperRepository discussionSqlRepository = new DiscussionDapperRepository();

    [HttpGet(ActionName = "GetAll")]
    public async Task GetAllDiscussions() {
        var sections = await this.sectionSqlRepository.GetAllSectionsAsync();

        if(sections is not null && sections.Any()) {
            List<KeyValuePair<string?, object>> sectionInfoPairs = new List<KeyValuePair<string?, object>>();
            foreach (var section in sections)
            {
                var discussionsIds = await discussionSectionSqlRepository.GetDiscussionsIdBySectionIdAsync(section.Id);
                var discussions = new List<Discussion>();
                foreach (var discussionsId in discussionsIds)
                {
                    discussions.Add(await discussionSqlRepository.GetDiscussionByIdAsync(discussionsId));
                }
                section.Discussions.AddRange(discussions);
                sectionInfoPairs.Add(new KeyValuePair<string?, object>(section.Id.ToString(), section));
            }
            Dictionary<string?, object> discussionsDictionary = new Dictionary<string?, object>(sectionInfoPairs);
            await WriteViewAsync(new Discussion(), discussionsDictionary, "index", "discussions");
        }
        else {
            await new ErrorController().NotFound(nameof(sections));
        }
    }
}