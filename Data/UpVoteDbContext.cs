using Microsoft.EntityFrameworkCore;
using UpVote.Models;

namespace UpVote.Data
{
    public class UpVoteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<UserDiscussion> UsersDiscussions { get; set; }
        public DbSet<DiscussionSection> DiscussionsSections { get; set; }

        public UpVoteDbContext(DbContextOptions<UpVoteDbContext> options) : base(options) {}
    }
}