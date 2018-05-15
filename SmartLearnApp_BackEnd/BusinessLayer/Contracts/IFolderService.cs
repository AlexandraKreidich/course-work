using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models.Card;
using BusinessLayer.Models.Folder;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface IFolderService
    {
        [ItemCanBeNull]
        Task<IEnumerable<FolderResponseBlModel>> GetUserFolders(int userId);

        [ItemCanBeNull]
        Task<IEnumerable<CardBlModel>> GetFolderCards(int folderId);
    }
}