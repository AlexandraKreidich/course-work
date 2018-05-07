using Common;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class User
    {
        public int Id { get; set; }
        [NotNull]
        public byte[] Salt { get; set; }
        [NotNull]
        public string FirstName { get; set; }
        [NotNull]
        public string LastName { get; set; }
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public byte[] PasswordHash { get; set; }
    }
}
