//Обновление данных

using System.ComponentModel.DataAnnotations;

namespace AppClient.Models.DTOs.User
{
    public class UpdateUserDto
    {
        [MinLength(2)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        [MinLength(6)]
        public string NewPassword { get; set; }
    }
}
