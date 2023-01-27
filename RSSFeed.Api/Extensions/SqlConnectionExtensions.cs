using Microsoft.EntityFrameworkCore;
using RSSFeed.Db;

namespace RSSFeed.Api.Extensions
{
    public static class SqlConnectionExtensions
    {
        public static IServiceCollection ConfigureSqliteContext(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlite(configuration.GetConnectionString("Sqlite")));
            return services;
        }
    }
}
