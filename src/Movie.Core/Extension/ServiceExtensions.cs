using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Movie.Core.Config;

namespace Movie.Core.Extension
{
    public static class ServiceExtensions
    {
        public static void Configs(this IServiceCollection services, WebApplication builder)
        {
            var jwtBearerTokenSettings = builder.Configuration.GetSection("JwtBearerTokenSettings");
            services.Configure<JwtBearerTokenSettings>(jwtBearerTokenSettings);
        }
    }
}
