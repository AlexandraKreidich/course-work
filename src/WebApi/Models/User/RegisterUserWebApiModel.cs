using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace WebApi.Models.User
{
    public class RegisterUserWebApiModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public RegisterUserWebApiModel(
            [NotNull] string firstName,
            [NotNull] string lastName,
            [NotNull] string email,
            [NotNull] string password
        )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
