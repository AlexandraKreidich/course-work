using System.Threading.Tasks;
using BusinessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FolderController : Controller
    {
        [NotNull] 
        private readonly IFolderService _folderService;

        public FolderController([NotNull] IFolderService folderService)
        {
            _folderService = folderService;
        }

        // GET /folder (get all folders for user)
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET /folder/{id}/cards (get cards in selected foder)
        // PUT /folder (add or update folder)
        // DELTE /folder/{id} (delete folder by id)

    }
}