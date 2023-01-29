using Microsoft.AspNetCore.Identity;
using RSSFeed.Db;
using RSSFeed.Models.Entities;

namespace RSSFeed.Api.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
