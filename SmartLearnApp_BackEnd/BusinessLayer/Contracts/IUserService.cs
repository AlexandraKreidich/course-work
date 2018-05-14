using System.Threading.Tasks;
using BusinessLayer.Models.User;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IUserService
    {
        [ItemCanBeNull]
        Task<UserBlModel> Login([NotNull] string email, [NotNull] string password);

        [ItemCanBeNull]
        Task<UserBlModel> Register([NotNull] RegisterUserBlModel user);
    }
}
