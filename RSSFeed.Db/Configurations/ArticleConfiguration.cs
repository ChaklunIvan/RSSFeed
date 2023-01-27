using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSSFeed.Models.Entities;

namespace RSSFeed.Db.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles")
                .HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .IsRequired();

            builder.Property(a => a.Url)
                .IsRequired();

            builder.Property(a => a.SubscriptionDate)
                .IsRequired();

            builder.Property(a => a.State)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
