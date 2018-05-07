using JetBrains.Annotations;

namespace WebApi.Contracts
{
    public interface IWebApiSettings
    {
        [NotNull]
        string JwtKey { get; }
        [NotNull]
        string JwtExpireDays { get; }
        [NotNull]
        string JwtIssuer { get; }
    }
}
