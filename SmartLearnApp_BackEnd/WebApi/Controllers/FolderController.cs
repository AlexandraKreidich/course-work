using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models.Card;
using BusinessLayer.Models.Folder;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;
using WebApi.Models.Card;
using WebApi.Models.Folder;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class FolderController : Controller
    {
        [NotNull] 
        private readonly IFolderService _folderService;

        public FolderController([NotNull] IFolderService folderService)
        {
            _folderService = folderService;
        }

        // GET /folder/get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int userId = HttpContext.User.GetUserId();

            IEnumerable<FolderResponseBlModel> folderResponseBlModels = await _folderService.GetUserFolders(userId);

            return Ok
            (
                folderResponseBlModels?.Select(Mapper.Map<FolderResponseWebApiModel>)
            );
        }

        // GET /folder/{id}/cards
        [HttpGet("{id:int}/cards")]
        public async Task<IActionResult> GetFolderCards([FromQuery] int id)
        {
            IEnumerable<CardBlModel> cardBlModels = await _folderService.GetFolderCards(id);

            return Ok
            (
                cardBlModels?.Select(Mapper.Map<CardWebApiModel>)
            );
        }

        // PUT /folder/put
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FolderRequestWebApiModel folder)
        {
            
            return Ok();
        }

        // DELTE /folder/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            return Ok();
        }

    }
}