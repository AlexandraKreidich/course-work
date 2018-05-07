using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IUserService
    {
        [ItemCanBeNull]
        Task<UserModel> Login([NotNull] string email, [NotNull] string password);
        [ItemCanBeNull]
        Task<UserModel> Register([NotNull] RegisterUserBlModel user);
    }
}
