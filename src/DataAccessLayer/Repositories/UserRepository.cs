using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAccessLayer.Repositories
{
    [UsedImplicitly]
    internal class UserRepository : IUserRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;


        public UserRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }

        public async Task<UserResponse> GetUser(string email)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                User user = await connection.QuerySingleOrDefaultAsync<User>(
                    "GetUser",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<UserResponse>(user);
            }
        }

        public async Task<int> Register(UserRequest userRequest)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddUser",
                    new {
                        Email = userRequest.Email,
                        FirstName = userRequest.FirstName,
                        LastName = userRequest.LastName,
                        PasswordHash = userRequest.PasswordHash,
                        Salt = userRequest.Salt
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }
}
