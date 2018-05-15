using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models.Card;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface ICardService
    {
        void AnswerOnCard([NotNull] CardAnswerBlModel card);

        [ItemNotNull]
        Task<CardBlModel> AddOrUpdateCard(CardBlModel cardDalModel);

        [ItemCanBeNull]
        Task<IEnumerable<CardBlModel>> GetCardsForUserToRepeat(int userId);

        [ItemCanBeNull]
        Task<IEnumerable<CardBlModel>> GetMissedCards(int userId);

        void RescheduleMissedCards(int[] cardIds);

        void DeleteCard(int cardId);
    }
}