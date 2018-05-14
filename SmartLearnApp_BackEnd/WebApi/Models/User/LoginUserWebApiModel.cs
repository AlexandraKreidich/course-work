using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.User
{
    public class LoginUserWebApiModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
