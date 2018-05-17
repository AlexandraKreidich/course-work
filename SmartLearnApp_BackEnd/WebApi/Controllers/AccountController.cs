using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Models.User;
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
        public async Task<IActionResult> Login([NotNull] [FromBody]LoginUserWebApiModel userWebApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserBlModel userBl = await _userService.Login(userWebApiModel.Email.ToLower(), userWebApiModel.Password);

            if (userBl == null)
            {
                return BadRequest("Invalid login or password");
            }

            string token = _jwtService.GenerateJwtToken(userBl);

            return Ok(new ResponseUserWebApiModel
            (
                userBl.Id,
                userBl.FirstName,
                userBl.LastName,
                userBl.Email,
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
                model.Email.ToLower(),
                model.FirstName,
                model.LastName,
                model.Password
            );

            UserBlModel userBl = await _userService.Register(Mapper.Map<RegisterUserBlModel>(registerUserModel));

            if (userBl == null)
            {
                return BadRequest("User already exists");
            }

            string token = _jwtService.GenerateJwtToken(userBl);

            return Ok(new ResponseUserWebApiModel
                (
                    userBl.Id,
                    userBl.FirstName,
                    userBl.LastName,
                    userBl.Email,
                    token
                ));
        }
    }
}