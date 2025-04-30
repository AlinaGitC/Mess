//Добавление участников

using System.ComponentModel.DataAnnotations;

namespace AppClient.Models.DTOs.Chat
{
    public class AddMembersDto
    {
        [Required]
        public int ChatId { get; set; }

        [Required, MinLength(1)]
        public List<int> UserIds { get; set; }
    }
}
