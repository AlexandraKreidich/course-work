using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IFolderRepository
    {
        [ItemCanBeNull]
        Task<IEnumerable<FolderDalModel>> GetUserFolders(int userId);

        [ItemCanBeNull]
        Task<IEnumerable<CardDalModel>> GetFolderCards(int folderId);

        Task<int> AddOrUpdateFolder([NotNull] FolderDalModel folderDalModel);

        void DeleteFolder(int folderId);
    }
}