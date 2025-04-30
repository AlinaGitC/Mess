//Ответ с сообщением
using AppServerTest.Models.DTOs.Auth;

namespace AppServerTest.Models.DTOs.Message
{
    public class MessageResponseDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public UserDto Sender { get; set; }
        public List<FileInfoDto> Files { get; set; } = new();
    }

    public class FileInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
