#pragma warning disable CS8601

namespace UpVote.Repositories;

using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using UpVote.Models;
using UpVote.Repositories.Base;

public class DiscussionJsonRepository : IDiscussionRepository
{
    private const string discussionsFilePath = "./Assets/discussions.json";
    
    public async Task CreateAsync(Discussion newDiscussion)
    {
        var json = await File.ReadAllTextAsync(discussionsFilePath);
        var allDiscussions = JsonSerializer.Deserialize<IEnumerable<Discussion>>(json) ?? Enumerable.Empty<Discussion>();

        newDiscussion.Id = allDiscussions.Max(discussion => discussion.Id) + 1;
        var resultJson = JsonSerializer.Serialize(allDiscussions.Append(newDiscussion));

        await File.WriteAllTextAsync(discussionsFilePath, resultJson);
    }

    public async Task<IEnumerable<Discussion>?> GetAllAsync()
    {
        var json = await File.ReadAllTextAsync(discussionsFilePath);
        return JsonSerializer.Deserialize<IEnumerable<Discussion>>(json);
    }

    public async Task<IEnumerable<Discussion>?> GetByIdAsync(int id)
    {
        var json = await File.ReadAllTextAsync(discussionsFilePath);
        var allDiscussions = JsonSerializer.Deserialize<IEnumerable<Discussion>>(json) ?? Enumerable.Empty<Discussion>();

        if (allDiscussions != Enumerable.Empty<Discussion>())
        {
            var searchedDiscussion = allDiscussions.FirstOrDefault(discussion => discussion.Id == id);
            return new Discussion[] {searchedDiscussion};
        }

        return new Discussion[]{};
    }
}