//Информация о чате

namespace AppServerTest.Models.DTOs.Chat
{
    public class ChatInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ChatType { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MembersCount { get; set; }
    }
}
