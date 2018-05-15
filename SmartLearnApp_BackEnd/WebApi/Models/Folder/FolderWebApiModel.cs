using JetBrains.Annotations;

namespace WebApi.Models.Folder
{
    public class FolderWebApiModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [NotNull]
        public string Name { get; set; }
    }
}