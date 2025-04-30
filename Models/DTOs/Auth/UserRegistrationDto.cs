//Данные для регистрации

using System.ComponentModel.DataAnnotations;

namespace AppClient.Models.DTOs.Auth
{
    public class UserRegistrationDto
    {
        [Required, MinLength(3)]
        public string Login { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)] // Указываем, что нужна только дата
        public DateTime BirthDate { get; set; }
    }
}
