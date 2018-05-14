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
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class CardsController : Controller
    {
        [NotNull] 
        private readonly ICardService _cardService;

        public CardsController([NotNull] ICardService cardService)
        {
            _cardService = cardService;
        }

        // GET /cards
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int userId = HttpContext.User.GetUserId();

            IEnumerable<CardBlModel> cardBlModels = await _cardService.GetCards(userId);

            return Ok
            (
                cardBlModels?.Select(Mapper.Map<CardWebApiModel>)
            );
        }

        // GET /cards/missed
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

        // PUT /cards
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

        // POST /cards/answer
        [HttpPost]
        public IActionResult Post([FromBody] CardAnswerRequestWebApiModel cardAnswerRequestWebApiModel)
        {
            _cardService.AnswerOnCard(Mapper.Map<CardAnswerRequestBlModel>(cardAnswerRequestWebApiModel));

            return Ok();
        }

        // DELETE /cards/{id}
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _cardService.DeleteCard(id);
        }
    }
}