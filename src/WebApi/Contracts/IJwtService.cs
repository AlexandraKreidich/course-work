using BusinessLayer.Models;
using JetBrains.Annotations;

namespace WebApi.Contracts
{
    public interface IJwtService
    {
        [NotNull]
        string GenerateJwtToken([NotNull] UserModel user);
    }
}
