using Common;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class UserModel
    {
        public int Id { get;}
        [NotNull]
        public string FirstName { get;}
        [NotNull]
        public string LastName { get;}
        [NotNull]
        public string Email { get;}

        public UserModel(
            int id,
            [NotNull] string firstName,
            [NotNull] string lastName,
            [NotNull] string email
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
