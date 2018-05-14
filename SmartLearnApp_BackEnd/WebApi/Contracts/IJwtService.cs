using BusinessLayer.Models.User;
using JetBrains.Annotations;

namespace WebApi.Contracts
{
    public interface IJwtService
    {
        [NotNull]
        string GenerateJwtToken([NotNull] UserBlModel userBl);
    }
}
