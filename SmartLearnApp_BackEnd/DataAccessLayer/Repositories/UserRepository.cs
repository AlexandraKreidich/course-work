using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public async Task<UserResponseDalModel> GetUser(string email)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                User user = await connection.QuerySingleOrDefaultAsync<User>(
                    "GetUser",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<UserResponseDalModel>(user);
            }
        }

        public async Task<IEnumerable<UserResponseDalModel>> GetUsersWithMissingCards()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<User> users = await connection.QueryAsync<User>(
                    "GetUsersWithMissingCards",
                    commandType: CommandType.StoredProcedure);

                return users?.Select(Mapper.Map<UserResponseDalModel>);
            }
        }

        public async Task<IEnumerable<UserResponseDalModel>> GetUsersHaveCardsToRepeat()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<User> users = await connection.QueryAsync<User>(
                    "GetUsersHaveCardsToRepeat",
                    commandType: CommandType.StoredProcedure);

                return users?.Select(Mapper.Map<UserResponseDalModel>);
            }
        }

        public async Task<int> Register(UserRequestDalModel userRequestDalModel)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddUser",
                    new {
                        Email = userRequestDalModel.Email,
                        FirstName = userRequestDalModel.FirstName,
                        LastName = userRequestDalModel.LastName,
                        PasswordHash = userRequestDalModel.PasswordHash,
                        Salt = userRequestDalModel.Salt
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }
}
