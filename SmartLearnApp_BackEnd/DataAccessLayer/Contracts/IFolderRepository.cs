using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface IFolderRepository
    {
        [ItemCanBeNull]
        Task<IEnumerable<FolderResponseDalModel>> GetUserFolders(int userId);

        [ItemCanBeNull]
        Task<IEnumerable<CardDalModel>> GetFolderCards(int folderId);
    }
}