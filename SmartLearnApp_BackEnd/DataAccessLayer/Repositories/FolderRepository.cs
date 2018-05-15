using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAccessLayer.Repositories
{
    public class FolderRepository : IFolderRepository
    {
        [NotNull] private readonly IDalSettings _settings;

        public FolderRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<FolderDalModel>> GetUserFolders(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Folder> folders = await connection.QueryAsync<Folder>
                (
                    "GetFolders",
                    new
                    {
                        UserId = userId
                    },
                    commandType: CommandType.StoredProcedure
                );

                return folders?.Select(Mapper.Map<FolderDalModel>);
            }
        }

        public async Task<IEnumerable<CardDalModel>> GetFolderCards(int folderId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Card> cards = await connection.QueryAsync<Card>
                (
                    "GetFolderCards",
                    new
                    {
                        FolderId = folderId
                    },
                    commandType: CommandType.StoredProcedure
                );

                return cards?.Select(Mapper.Map<CardDalModel>);
            }
        }

        public async Task<int> AddOrUpdateFolder(FolderDalModel folderDalModel)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdateFolder",
                    new
                        {
                            Id = folderDalModel.Id,
                            UserId = folderDalModel.UserId,
                            Name = folderDalModel.Name
                        },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public async void DeleteFolder(int folderId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "DeleteFolder",
                    new
                        {
                            Id = folderId
                        },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
