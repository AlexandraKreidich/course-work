using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class FolderDalModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [NotNull]
        public string Name { get; set; }

        public FolderDalModel(
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
