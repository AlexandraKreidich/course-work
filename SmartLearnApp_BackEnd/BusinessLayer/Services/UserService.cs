using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;
using BusinessLayer.Models.User;
using Common.Extensions;

namespace BusinessLayer.Services
{
    [UsedImplicitly]
    public class UserService : IUserService
    {
        [NotNull] private readonly IUserRepository _userRepository;

        public UserService([NotNull] IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserBlModel> Login(string email, string password)
        {
            email = email ?? throw new ArgumentNullException(nameof(email));
            password = password ?? throw new ArgumentNullException(nameof(password));

            UserResponseDalModel user = await _userRepository.GetUser(email);

            if (user == null)
            {
                // no user with this email
                return null;
            }

            byte[] passwordHash = CryptoService.GetHash(password, user.Salt).PasswordHash;

            // check if the password is right
            if (passwordHash.Select((b, i) => b == user.PasswordHash[i]).All(item => item))
            {
                UserBlModel userBlModel = new UserBlModel
                (
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email
                 );

                return userBlModel;
            }

            // wrong password
            return null;
        }

        public async Task<UserBlModel> Register(RegisterUserBlModel regModel)
        {
            regModel.EnsureObjectPropertiesNotNull();

            if (await _userRepository.GetUser(regModel.Email) != null)
            {
                // error, user with this email already exist
                return null;
            }

            PasswordObject data = CryptoService.GetHash(regModel.Password);

            UserRequestDalModel userToRegister = new UserRequestDalModel()
            {
                Email = regModel.Email,
                FirstName = regModel.FirstName,
                LastName = regModel.LastName,
                PasswordHash = data.PasswordHash,
                Salt = data.Salt
            };

            int userId = await _userRepository.Register(userToRegister);

            UserBlModel userBlModel = new UserBlModel
            (
                userId,
                userToRegister.FirstName,
                userToRegister.LastName,
                userToRegister.Email
            );

            return userBlModel;
        }

        public async Task<IEnumerable<UserBlModel>> GetUsersWithMissingCards()
        {
            IEnumerable<UserResponseDalModel> userResponseDalModels = await _userRepository.GetUsersWithMissingCards();

            return userResponseDalModels?.Select(Mapper.Map<UserBlModel>);
        }

        public async Task<IEnumerable<UserBlModel>> GetUsersHaveCardsToRepeat()
        {
            IEnumerable<UserResponseDalModel> userResponseDalModels = await _userRepository.GetUsersHaveCardsToRepeat();

            return userResponseDalModels?.Select(Mapper.Map<UserBlModel>);
        }
    }
}