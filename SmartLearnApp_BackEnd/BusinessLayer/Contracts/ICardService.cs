using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Models.Card;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface ICardService
    {
        void AnswerOnCard([NotNull] CardAnswerRequestBlModel card);

        [ItemNotNull]
        Task<CardBlModel> AddOrUpdateCard(CardBlModel cardDalModel);

        [ItemCanBeNull]
        Task<IEnumerable<CardBlModel>> GetCards(int userId);

        [ItemCanBeNull]
        Task<IEnumerable<CardBlModel>> GetMissedCards(int userId);

        void DeleteCard(int cardId);
    }
}