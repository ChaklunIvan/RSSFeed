using RSSFeed.Services;
using RSSFeed.Services.Interfaces;

namespace RSSFeed.Api.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IFeedService, FeedService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
