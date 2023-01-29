using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RSSFeed.Models.Constans;
using System.Text;

namespace RSSFeed.Api.Extensions
{
    public static class JwtExtensions
    {
        public static IServiceCollection ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection(JwtConstans.JwtSettings);
            var secretKey = jwtSettings.GetSection(JwtConstans.Key).Value;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtSettings.GetSection(JwtConstans.Issuer).Value,
                            ValidAudience = jwtSettings.GetSection(JwtConstans.Audience).Value,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                        };
                    });

            return services;
        }
    }
}
