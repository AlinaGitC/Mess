using System.Text.RegularExpressions;
using AppServerTest.Data;
using AppServerTest.Models;
using AppServerTest.Models.DTOs.Message;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using AppServerTest.Models.DTOs;

namespace AppServerTest.Hubs
{
    

    public class ChatHub : Hub
    {
        private readonly MessengerDbContext _context;

        public ChatHub(MessengerDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(SendMessageDto messageDto)
        {
            // Явно загружаем связанные данные
            var user = await _context.Users.FindAsync(messageDto.UserId);
            if (user == null)
            {
                throw new HubException("User not found");
            }

            var message = new Message
            {
                ID_Chat = messageDto.ChatId,
                ID_User = messageDto.UserId,
                ContentMessages = messageDto.Content,
                Timestamp = DateTime.UtcNow
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            // Явно загружаем сообщение с включенными связанными данными
            var response = await _context.Messages
                .Include(m => m.ID_User)  // Явно включаем пользователя
                .Include(m => m.Files) // Явно включаем файлы
                .Where(m => m.ID == message.ID)
                .Select(m => new MessageResponseDto
                {
                    Id = m.ID,
                    Content = m.ContentMessages,
                    Timestamp = (DateTime)m.Timestamp,
                    Sender = new UserDto
                    {
                        Id = m.ID_UserNavigation.ID,
                        Login = m.ID_UserNavigation.Login,
                        AvatarUrl = m.ID_UserNavigation.AvatarUrl
                    },
                    Files = m.Files.Select(f => new FileInfoDto
                    {
                        Id = f.ID,
                        Name = f.FileName,
                        Url = f.Url // Исправлено с StorageUrl на Url (по схеме БД)
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            await Clients.Group($"chat-{messageDto.ChatId}")
                        .SendAsync("ReceiveMessage", response);
        }

        public async Task JoinChat(int chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"chat-{chatId}");
        }

        public async Task LeaveChat(int chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"chat-{chatId}");
        }
    }
   
}
