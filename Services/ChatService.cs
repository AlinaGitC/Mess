using AppClient.Models;
using AppClient.Models.DTOs.Message;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClient.Services
{
    public class ChatService //: IDisposable
    {
        private HubConnection _connection;

        public async Task ConnectAsync(string hubUrl)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .Build();

            await _connection.StartAsync();
        }

        /*private HubConnection _connection;

        public event Action<MessageResponseDto> MessageReceived;

        public async Task ConnectAsync(string hubUrl)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();

            _connection.On<MessageResponseDto>("ReceiveMessage", message =>
                MessageReceived?.Invoke(message));

            await _connection.StartAsync();
        }

        public async Task SendMessageAsync(SendMessageDto message)
        {
            await _connection.InvokeAsync("SendMessage", message);
        }

        public async Task JoinChatAsync(int chatId) =>
            await _connection.InvokeAsync("JoinChat", chatId);

        public async Task LeaveChatAsync(int chatId) =>
            await _connection.InvokeAsync("LeaveChat", chatId);

        public void Dispose() => _connection?.DisposeAsync();*/
    }
}
