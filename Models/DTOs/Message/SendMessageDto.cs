//Отправка сообщения

using System.ComponentModel.DataAnnotations;

namespace AppClient.Models.DTOs.Message
{
    public class SendMessageDto
    {
        [Required]
        public int ChatId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(2000)]
        public string Content { get; set; }

        public List<FileAttachmentDto> Files { get; set; } = new();
    }

    public class FileAttachmentDto
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
