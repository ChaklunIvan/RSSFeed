using Microsoft.EntityFrameworkCore;
using RSSFeed.Db.Configurations;
using RSSFeed.Models.Entities;

namespace RSSFeed.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ArticleConfiguration());
        }
    }
}
