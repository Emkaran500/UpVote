namespace UpVote.Controllers;

using UpVote.Controllers.Base;
using UpVote.Repositories;
using UpVote.HttpAttributes;
using Upvote.Models;

public class DiscussionController : BaseController
{
    private readonly DiscussionDapperRepository discussionSqlRepository = new DiscussionDapperRepository();

    [HttpGet(ActionName = "GetAll")]
    public async Task GetAllDiscussions() {
        var discussions = await this.discussionSqlRepository.GetAllDiscussionsAsync();

        if(discussions is not null && discussions.Any()) {
            List<KeyValuePair<string?, object>> discussionInfoPairs = new List<KeyValuePair<string?, object>>();
            foreach (var discussion in discussions)
            {
                discussionInfoPairs.Add(new KeyValuePair<string?, object>(discussion.Id.ToString(), discussion));
            }
            Dictionary<string?, object> discussionsDictionary = new Dictionary<string?, object>(discussionInfoPairs);
            await WriteViewAsync(discussions.FirstOrDefault(), discussionsDictionary, "index", "users");
        }
        else {
            await new ErrorController().NotFound(nameof(discussions));
        }
    }
}