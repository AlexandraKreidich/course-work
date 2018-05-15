using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models.Card;
using Common;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;

namespace BusinessLayer.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        private DateTime CountNewRepeatAtDate(DateTime learnDate, DateTime lastDayRepeatAt)
        {
            int days = 2 * ((lastDayRepeatAt - learnDate).Days + 1);

            return learnDate.AddDays(days);
        }

        public void RescheduleMissedCards(int[] cardIds)
        {
            foreach (int cardId in cardIds)
            {
                CardRescheduleDalModel cardRescheduleDalModel = new CardRescheduleDalModel(
                    cardId,
                    DateTime.Now.Date,
                    DateTime.Now.Date,
                    DateTime.Now.Date.AddDays(1).Date
                );

                _cardRepository.RescheduleMissedCards(cardRescheduleDalModel);
            }
        }

        public void AnswerOnCard(CardAnswerBlModel card)
        {
            if (card.Result == AnswerResult.Ok)
            {
                CardAnswerDalModel cardAnswerDalModel = new CardAnswerDalModel(
                    card.Id,
                    card.LearnDate,
                    card.ShouldRepeatAt,
                    CountNewRepeatAtDate(card.LearnDate, card.LastDayRepeatedAt)
                );

                _cardRepository.UpdateCardDates(cardAnswerDalModel);
            }

            // ! should check documents
            if (card.Result == AnswerResult.Forget)
            {
                CardAnswerDalModel cardAnswerDalModel = new CardAnswerDalModel(
                    card.Id,
                    card.LastDayRepeatedAt,
                    card.ShouldRepeatAt,
                    card.ShouldRepeatAt.AddDays(1)
                );

                _cardRepository.UpdateCardDates(cardAnswerDalModel);
            }
        }

        public async Task<CardBlModel> AddOrUpdateCard(CardBlModel cardDalModel)
        {
            // new
            if (cardDalModel.Id == 0)
            {
                CardDalModel cardRequestDalModel = new CardDalModel
                (
                    cardDalModel.Id,
                    cardDalModel.UserId,
                    cardDalModel.FolderId,
                    cardDalModel.Cue,
                    cardDalModel.Answer,
                    DateTime.Now.Date,
                    DateTime.Now.Date,
                    DateTime.Now.Date.AddDays(1).Date
                );

                int id = await _cardRepository.AddOrUpdateCard(cardRequestDalModel);

                return new CardBlModel
                (
                    id,
                    cardDalModel.UserId,
                    cardDalModel.FolderId,
                    cardRequestDalModel.Cue,
                    cardRequestDalModel.Answer,
                    cardRequestDalModel.LearnDate,
                    cardRequestDalModel.LastDayRepeatedAt,
                    cardRequestDalModel.ShouldRepeatAt
                );
            }
            // update
            else
            {
                CardDalModel cardRequestDalModel = new CardDalModel
                (
                    cardDalModel.Id,
                    cardDalModel.UserId,
                    cardDalModel.FolderId,
                    cardDalModel.Cue,
                    cardDalModel.Answer,
                    cardDalModel.LearnDate,
                    cardDalModel.LastDayRepeatedAt,
                    cardDalModel.ShouldRepeatAt
                );

                int id = await _cardRepository.AddOrUpdateCard(cardRequestDalModel);

                return new CardBlModel
                (
                    cardDalModel.Id,
                    cardDalModel.UserId,
                    cardDalModel.FolderId,
                    cardDalModel.Cue,
                    cardDalModel.Answer,
                    cardDalModel.LearnDate,
                    cardDalModel.LastDayRepeatedAt,
                    cardDalModel.ShouldRepeatAt
                );
            }
        }

        public async Task<IEnumerable<CardBlModel>> GetCardsForUserToRepeat(int userId)
        {
            IEnumerable<CardDalModel> cardDalModels = await _cardRepository.GetCards(userId);

            return cardDalModels?.Select(Mapper.Map<CardBlModel>);
        }

        public async Task<IEnumerable<CardBlModel>> GetMissedCards(int userId)
        {
            IEnumerable<CardDalModel> cardDalModels = await _cardRepository.GetMissingCards(userId);

            return cardDalModels?.Select(Mapper.Map<CardBlModel>);
        }

        public void DeleteCard(int cardId)
        {
            _cardRepository.DeleteCard(cardId);
        }
    }
}
