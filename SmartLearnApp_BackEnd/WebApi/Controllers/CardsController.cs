using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models.Card;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;
using WebApi.Models.Card;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CardsController : Controller
    {
        [NotNull]
        private readonly ICardService _cardService;

        public CardsController([NotNull] ICardService cardService)
        {
            _cardService = cardService;
        }

        // GET /cards -> Get cards for user to repeat
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int userId = HttpContext.User.GetUserId();

            IEnumerable<CardBlModel> cardBlModels = await _cardService.GetCardsForUserToRepeat(userId);

            return Ok
            (
                cardBlModels?.Select(Mapper.Map<CardWebApiModel>)
            );
        }

        // GET /cards/missed -> get cards that user missed
        [HttpGet]
        [Route("missed")]
        public async Task<IActionResult> GetMissed()
        {
            int userId = HttpContext.User.GetUserId();

            IEnumerable<CardBlModel> cardBlModels = await _cardService.GetMissedCards(userId);

            return Ok
            (
                cardBlModels?.Select(Mapper.Map<CardWebApiModel>)
            );
        }

        // PUT /cards -> add or update card
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CardWebApiModel cardWebApiModel)
        {
            CardBlModel cardBlModel =
                await _cardService.AddOrUpdateCard(Mapper.Map<CardBlModel>(cardWebApiModel));

            return Ok
            (
                Mapper.Map<CardWebApiModel>(cardBlModel)
            );
        }

        // POST /cards/answer -> answer on card
        [HttpPost]
        [Route("answer")]
        public IActionResult AnswerOnCard([FromBody] CardAnswerWebApiModel cardAnswerWebApiModel)
        {
            _cardService.AnswerOnCard(Mapper.Map<CardAnswerBlModel>(cardAnswerWebApiModel));

            return Ok();
        }

        // POST /cards/reschedule -> reschedule missed cards
        [HttpPost]
        [Route("reschedule")]
        public IActionResult RescheduleMissedCards(int[] cardIds)
        {
            _cardService.RescheduleMissedCards(cardIds);

            return Ok();
        }

        // DELETE /cards/{id} -> delete card
        [HttpDelete("{id:int}")]
        public void Delete([FromQuery] int id)
        {
            _cardService.DeleteCard(id);
        }
    }
}