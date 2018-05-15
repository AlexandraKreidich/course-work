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

        public async Task<IEnumerable<FolderBlModel>> GetUserFolders(int userId)
        {
            IEnumerable<FolderDalModel>
                folderResponseDalModels = await _folderRepository.GetUserFolders(userId);

            return folderResponseDalModels?.Select(Mapper.Map<FolderBlModel>);
        }

        public async Task<IEnumerable<CardBlModel>> GetFolderCards(int folderId)
        {
            IEnumerable<CardDalModel> cardDalModels = await _folderRepository.GetFolderCards(folderId);

            return cardDalModels?.Select(Mapper.Map<CardBlModel>);
        }

        public async Task<FolderBlModel> AddOrUpdateFolder(FolderBlModel folderBlModel)
        {
            int id = await _folderRepository.AddOrUpdateFolder(Mapper.Map<FolderDalModel>(folderBlModel));

            return new FolderBlModel
            (
                (id != 0) ? id : folderBlModel.Id,
                folderBlModel.UserId,
                folderBlModel.Name
            );
        }

        public void DeleteFolder(int folderId)
        {
            _folderRepository.DeleteFolder(folderId);
        }
    }
}
