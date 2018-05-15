using JetBrains.Annotations;

namespace BusinessLayer.Models.Folder
{
    public class FolderBlModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [NotNull]
        public string Name { get; set; }

        public FolderBlModel(
            int id,
            int userId,
            [NotNull] string name
        )
        {
            Id = id;
            UserId = userId;
            Name = name;
        }
    }
}
