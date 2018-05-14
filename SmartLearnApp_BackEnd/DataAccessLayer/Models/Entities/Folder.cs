using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class Folder
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [NotNull]
        public string Name { get; set; }
    }
}
