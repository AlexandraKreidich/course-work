using JetBrains.Annotations;

namespace BusinessLayer.Models.Folder
{
    public class FolderRequestBlModel
    {
        public int UserId { get; set; }

        [NotNull]
        public string Name { get; set; }

        public FolderRequestBlModel(
            int userId,
            [NotNull] string name
        )
        {
            Name = name;
            UserId = userId;
        }
    }
}
