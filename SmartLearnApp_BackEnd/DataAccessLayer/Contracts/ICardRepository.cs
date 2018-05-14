using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface ICardRepository
    {
        void UpdateCardDates([NotNull] CardAnswerRequestDalModel cardAnswerDalModel);

        [ItemCanBeNull]
        Task<IEnumerable<CardDalModel>> GetCards(int userId);

        [ItemCanBeNull]
        Task<IEnumerable<CardDalModel>> GetMissingCards(int userId);

        Task<int> AddOrUpdateCard([NotNull] CardDalModel cardDalModel);

        void DeleteCard(int cardId);
    }
}