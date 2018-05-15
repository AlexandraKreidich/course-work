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
    public class CardRepository : ICardRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;

        public CardRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }

        public async void UpdateCardDates(CardAnswerDalModel cardAnswerDalModel)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "UpdateCardDates",
                    new
                    {
                        Id = cardAnswerDalModel.Id,
                        LearnDate = cardAnswerDalModel.LearnDate.Date,
                        LastDayRepeatedAt = cardAnswerDalModel.LastDayRepeatedAt.Date,
                        ShouldRepeatAt = cardAnswerDalModel.ShouldRepeatAt.Date
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CardDalModel>> GetCards(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Card> cards = await connection.QueryAsync<Card>
                (
                    "GetCards",
                    new
                    {
                        UserId = userId
                    },
                    commandType: CommandType.StoredProcedure
                );

                return cards.Select(Mapper.Map<CardDalModel>);
            }
        }

        public async Task<IEnumerable<CardDalModel>> GetMissingCards(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Card> cards = await connection.QueryAsync<Card>
                (
                    "GetMissingCards",
                    new
                    {
                        UserId = userId
                    },
                    commandType: CommandType.StoredProcedure
                );

                return cards.Select(Mapper.Map<CardDalModel>);
            }
        }

        public async Task<int> AddOrUpdateCard(CardDalModel cardDalModel)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdateCard",
                    new
                    {
                        Id = cardDalModel.Id,
                        UserId = cardDalModel.UserId,
                        FolderId = cardDalModel.FolderId,
                        Cue = cardDalModel.Cue,
                        Answer = cardDalModel.Answer,
                        LearnDate = cardDalModel.LearnDate.Date,
                        LastDayRepeatedAt = cardDalModel.LastDayRepeatedAt.Date,
                        ShouldRepeatAt = cardDalModel.ShouldRepeatAt.Date
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public async void RescheduleMissedCards(CardRescheduleDalModel cardRescheduleDalModel)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "UpdateCardDates",
                    new
                        {
                            Id = cardRescheduleDalModel.Id,
                            LearnDate = cardRescheduleDalModel.LearnDate.Date,
                            LastDayRepeatedAt = cardRescheduleDalModel.LastDayRepeatedAt.Date,
                            ShouldRepeatAt = cardRescheduleDalModel.ShouldRepeatAt.Date
                        },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public async void DeleteCard(int cardId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.ExecuteAsync(
                    "DeleteCard",
                    new
                    {
                        Id = cardId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
