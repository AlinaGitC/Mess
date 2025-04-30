using AppClient.Models;
using AppClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppClient.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private readonly ChatService _chatService;
        private int _currentUserId;
        private int _currentChatId;

        private ObservableCollection<Message> _messages;
        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set { _messages = value; OnPropertyChanged(); }
        }

        public ChatViewModel(ApiService apiService, ChatService chatService)
        {
            _apiService = apiService;
            _chatService = chatService;
            Messages = new ObservableCollection<Message>();

            //_chatService.MessageReceived += OnMessageReceived;
        }

        public async Task Initialize(int userId, int chatId)
        {
            _currentUserId = userId;
            _currentChatId = chatId;

            // Загрузка истории сообщений
            //var history = await _apiService.GetChatMessages(chatId);
            //Messages = new ObservableCollection<Message>(history);

            //// Подключение к чату
            //await _chatService.ConnectAsync("http://192.168.0.130:5099/swagger/index.html");
            //await _chatService.JoinChat(chatId);
        }

        public async Task SendMessage(string content)
        {
            //await _chatService.SendMessage(_currentChatId, _currentUserId, content);
        }

        private void OnMessageReceived(Message message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(message);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
