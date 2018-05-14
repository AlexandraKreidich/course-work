using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IUserRepository
    {
        Task<int> Register(UserRequestDalModel userRequestDalModel);

        [ItemCanBeNull]
        Task<UserResponseDalModel> GetUser([NotNull] string email);
    }
}