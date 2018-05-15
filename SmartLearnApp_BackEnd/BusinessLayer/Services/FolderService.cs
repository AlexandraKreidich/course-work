using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models.Card;
using BusinessLayer.Models.Folder;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer.Services
{
    public class FolderService : IFolderService
    {
        [NotNull] 
        private readonly IFolderRepository _folderRepository;

        public FolderService([NotNull] IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public async Task<IEnumerable<FolderResponseBlModel>> GetUserFolders(int userId)
        {
            IEnumerable<FolderResponseDalModel>
                folderResponseDalModels = await _folderRepository.GetUserFolders(userId);

            return folderResponseDalModels?.Select(Mapper.Map<FolderResponseBlModel>);
        }

        public async Task<IEnumerable<CardBlModel>> GetFolderCards(int folderId)
        {
            IEnumerable<CardDalModel> cardDalModels = await _folderRepository.GetFolderCards(folderId);

            return cardDalModels?.Select(Mapper.Map<CardBlModel>);
        }
    }
}
