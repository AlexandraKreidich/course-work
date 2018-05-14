using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using WebApi.Contracts;

namespace WebApi
{
    public class Settings : IDalSettings, IWebApiSettings
    {
        [NotNull]
        private readonly IConfiguration _configuration;

        public string ConnectionString => _configuration[nameof(ConnectionString)];
        public string JwtKey => _configuration[nameof(JwtKey)];
        public string JwtExpireDays => _configuration[nameof(JwtExpireDays)];
        public string JwtIssuer => _configuration[nameof(JwtIssuer)];

        public Settings([NotNull] IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}