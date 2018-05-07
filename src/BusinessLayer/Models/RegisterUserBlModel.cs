using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class RegisterUserBlModel
    {
        [NotNull]
        public string Email { get; }

        [NotNull]
        public string FirstName { get; }

        [NotNull]
        public string LastName { get; }

        [NotNull]
        public string Password { get; }


        public RegisterUserBlModel(
            [NotNull] string email,
            [NotNull] string firstName,
            [NotNull] string lastName,
            [NotNull] string password
        )
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}
