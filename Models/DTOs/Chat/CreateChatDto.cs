//Создание чата

using System.ComponentModel.DataAnnotations;

namespace AppClient.Models.DTOs.Chat
{
    public class CreateChatDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int ChatTypeId { get; set; }

        [Required]
        public int CreatorId { get; set; }

        public List<int> MemberIds { get; set; } = new();
    }
}
