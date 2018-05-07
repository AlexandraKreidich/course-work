using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using Common.Extensions;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

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

        public async Task<UserModel> Login(string email, string password)
        {
            email = email ?? throw new ArgumentNullException(nameof(email));
            password = password ?? throw new ArgumentNullException(nameof(password));

            UserResponse user = await _userRepository.GetUser(email);

            if (user == null)
            {
                // no user with this email
                return null;
            }

            byte[] passwordHash = CryptoService.GetHash(password, user.Salt).PasswordHash;

            // check if the password is right
            if (passwordHash.Select((b, i) => b == user.PasswordHash[i]).All(item => item))
            {
                UserModel userModel = new UserModel
                (
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email
                 );

                return userModel;
            }

            // wrong password
            return null;
        }

        public async Task<UserModel> Register(RegisterUserBlModel regModel)
        {
            regModel.EnsureObjectPropertiesNotNull();

            if (await _userRepository.GetUser(regModel.Email) != null)
            {
                // error, user with this email already exist
                return null;
            }

            PasswordObject data = CryptoService.GetHash(regModel.Password);

            UserRequest userToRegister = new UserRequest()
            {
                Email = regModel.Email,
                FirstName = regModel.FirstName,
                LastName = regModel.LastName,
                PasswordHash = data.PasswordHash,
                Salt = data.Salt
            };

            int userId = await _userRepository.Register(userToRegister);

            UserModel userModel = new UserModel
            (
                userId,
                userToRegister.FirstName,
                userToRegister.LastName,
                userToRegister.Email
            );

            return userModel;
        }
    }
}