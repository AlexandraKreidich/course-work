using JetBrains.Annotations;

namespace BusinessLayer.Models.Folder
{
    public class FolderResponseBlModel
    {
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        public FolderResponseBlModel(
            int id,
            string name
        )
        {
            Id = id;
            Name = name;
        }
    }
}
