//Данные для входа

using System.ComponentModel.DataAnnotations;

namespace AppClient.Models.DTOs.Auth
{
    public class UserLoginDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
