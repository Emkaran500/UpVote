using Microsoft.EntityFrameworkCore;
using Upvote.Models;

namespace UpVote.Data
{
    public class UpVoteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<User> Discussions { get; set; }
        public DbSet<User> Sections { get; set; }

        public UpVoteDbContext(DbContextOptions<UpVoteDbContext> options) : base(options) {}
    }
}