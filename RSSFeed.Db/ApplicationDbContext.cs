using Microsoft.EntityFrameworkCore;
using RSSFeed.Models.Entities;

namespace RSSFeed.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }
    }
}
