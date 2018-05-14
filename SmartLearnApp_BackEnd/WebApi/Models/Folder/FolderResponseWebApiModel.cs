using JetBrains.Annotations;

namespace WebApi.Models.Folder
{
    public class FolderResponseWebApiModel
    {
        public int Id { get; set; }

        [NotNull] 
        public string Name { get; set; }

        public FolderResponseWebApiModel(
            int id, 
            [NotNull] string name
        )
        {
            Id = id;
            Name = name;
        }
    }
}
