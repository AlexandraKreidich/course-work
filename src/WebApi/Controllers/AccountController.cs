using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;
using WebApi.Models.User;
using AutoMapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        [NotNull]
        private readonly IUserService _userService;

        [NotNull]
        private readonly IJwtService _jwtService;

        public AccountController([NotNull] IUserService userService, [NotNull] IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        // POST /account/login
        [HttpPost]
        public async Task<IActionResult> Login([NotNull] [FromBody]LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel user = await _userService.Login(model.Email, model.Password);

            if (user == null)
            {
                return BadRequest("Invalid login or password");
            }

            string token = _jwtService.GenerateJwtToken(user);

            return Ok(new ResponseModel
            (
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                token
            ));
        }

        // POST /account/register
        [HttpPost]
        public async Task<IActionResult> Register([NotNull] [FromBody] RegisterUserWebApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RegisterUserWebApiModel registerUserModel = new RegisterUserWebApiModel
            (
                model.Email,
                model.FirstName,
                model.LastName,
                model.Password
            );

            UserModel user = await _userService.Register(Mapper.Map<RegisterUserBlModel>(registerUserModel));

            if (user == null)
            {
                return BadRequest("User already exists");
            }

            string token = _jwtService.GenerateJwtToken(user);

            return Ok(new ResponseModel
                (
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    token
                ));
        }
    }
}