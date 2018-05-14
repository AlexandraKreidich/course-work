using JetBrains.Annotations;

namespace WebApi.Models.Folder
{
    public class FolderRequestWebApiModel
    {
        [NotNull]
        public string Name { get; set; }
    }
}
