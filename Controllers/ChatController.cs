using AppServerTest.Data;
using AppServerTest.Models;
using AppServerTest.Models.DTOs.Chat;
using AppServerTest.Models.DTOs.Message;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServerTest.Models.DTOs;

namespace AppServerTest.Controllers
{
   

    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly MessengerDbContext _context;

        public ChatController(MessengerDbContext context)
        {
            _context = context;
        }

        [HttpGet("{chatId}/messages")]
        public async Task<ActionResult<List<MessageResponseDto>>> GetMessages(int chatId)
        {
            var messages = await _context.Messages
                .Include(m => m.ID_UserNavigation)  // Явная загрузка пользователя
                .Include(m => m.Files) // Явная загрузка файлов
                .Where(m => m.ID_Chat == chatId)
                .OrderBy(m => m.Timestamp)
                .Select(m => new MessageResponseDto
                {
                    Id = m.ID,
                    Content = m.ContentMessages,
                    Timestamp = (DateTime)m.Timestamp,
                    Sender = m.ID_UserNavigation != null ? new UserDto  // Проверка на null
                    {
                        Id = m.ID_UserNavigation.ID,
                        Login = m.ID_UserNavigation.Login,
                        AvatarUrl = m.ID_UserNavigation.AvatarUrl
                    } : null,
                    Files = m.Files != null ? m.Files.Select(f => new FileInfoDto  // Проверка на null
                    {
                        Id = f.ID,
                        Name = f.FileName,
                        Url = f.Url // Исправлено с StorageUrl на Url
                    }).ToList() : new List<FileInfoDto>()
                })
                .ToListAsync();

            return messages;
        }

        [HttpPost]
        public async Task<ActionResult<ChatInfoDto>> CreateChat([FromBody] CreateChatDto dto)
        {
            if (dto == null) return BadRequest("Invalid request data"); // CS8629 fix

            var chat = new Chat
            {
                Name = dto.Name,
                ID_ChatType = dto.ChatTypeId,
                CreatedDate = DateTime.UtcNow
            };

            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            // Добавляем создателя
            _context.ChatMembers.Add(new ChatMember
            {
                ID_Chat = chat.ID,
                ID_Userr = dto.CreatorId,
                ID_ChatRole = 1,
                DateJoining = DateTime.UtcNow
            });

            if (dto.MemberIds != null) // CS8629 fix
            {
                foreach (var userId in dto.MemberIds)
                {
                    _context.ChatMembers.Add(new ChatMember
                    {
                        ID_Chat = chat.ID,
                        ID_Userr = userId,
                        ID_ChatRole = 2,
                        DateJoining = DateTime.UtcNow
                    });
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new ChatInfoDto
            {
                Id = chat.ID,
                Name = chat.Name,
                CreatedAt = (DateTime)chat.CreatedDate,
                MembersCount = (dto.MemberIds?.Count ?? 0) + 1
            });
        }
    }
}
