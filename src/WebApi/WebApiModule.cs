using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Contracts;
using WebApi.Services;

namespace WebApi
{
    public static class WebApiModule
    {
        public static void Register([NotNull] IServiceCollection collection)
        {
            collection.AddSingleton<IJwtService, JwtService>();
            collection.AddSingleton<IHostedService, TimedHostedService>();
        }
    }
}
