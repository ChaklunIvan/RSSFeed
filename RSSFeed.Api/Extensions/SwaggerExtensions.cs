using Microsoft.OpenApi.Models;
using RSSFeed.Models.Constans;

namespace RSSFeed.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerGenerator(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = SwaggerConstans.ApiTitle, Version = SwaggerConstans.Version });
            });
            return services;
        }
    }
}
