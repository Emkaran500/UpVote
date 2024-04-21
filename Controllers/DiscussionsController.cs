namespace UpVote.Controllers;

using UpVote.Controllers.Base;
using UpVote.Repositories;
using UpVote.HttpAttributes;
using Upvote.Models;

public class DiscussionsController : BaseController
{
    private readonly DiscussionDapperRepository discussionSqlRepository = new DiscussionDapperRepository();
    private readonly UserDiscussionDapperRepository userDiscussionSqlRepository = new UserDiscussionDapperRepository();
    private readonly UserDapperRepository userSqlRepository = new UserDapperRepository();

    [HttpGet(ActionName = "GetAll")]
    public async Task GetAllDiscussions() {
        var discussions = await this.discussionSqlRepository.GetAllDiscussionsAsync();

        if(discussions is not null && discussions.Any()) {
            List<KeyValuePair<string?, object>> discussionInfoPairs = new List<KeyValuePair<string?, object>>();
            foreach (var discussion in discussions)
            {
                var usersIds = await userDiscussionSqlRepository.GetUsersIdByDiscussionIdAsync(discussion.Id);
                var users = new List<User>();
                foreach (var userId in usersIds)
                {
                    users.Add(await userSqlRepository.GetUserByIdAsync(userId));
                }
                discussion.Users.AddRange(users);
                discussionInfoPairs.Add(new KeyValuePair<string?, object>(discussion.Id.ToString(), discussion));
            }
            Dictionary<string?, object> discussionsDictionary = new Dictionary<string?, object>(discussionInfoPairs);
            await WriteViewAsync(discussions.FirstOrDefault(), discussionsDictionary, "index", "discussions");
        }
        else {
            await new ErrorController().NotFound(nameof(discussions));
        }
    }
}