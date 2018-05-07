using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.User
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
