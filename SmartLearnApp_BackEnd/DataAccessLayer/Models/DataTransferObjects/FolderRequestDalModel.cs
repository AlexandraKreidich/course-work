using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class FolderRequestDalModel
    {
        public int UserId { get; set; }

        [NotNull] 
        public string Name { get; set; }

        public FolderRequestDalModel(
            int userId,
            [NotNull] string name
        )
        {
            UserId = userId;
            Name = name;
        }
    }
}
