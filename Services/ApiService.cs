using AppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AppClient.Models.DTOs;
using AppClient.Models.DTOs.User;
using AppClient.Models.DTOs.Auth;
using AppClient.Models.DTOs.Message;
using AppClient.Models.DTOs.Chat;

namespace AppClient.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task LoginAsync(string login, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/auth/login",
                new { Login = login, Password = password });

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("Ошибка авторизации");
        }

        /*private readonly HttpClient _httpClient;

        public ApiService(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<UserProfileDto> LoginAsync(UserLoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserProfileDto>();
        }

        public async Task<List<MessageResponseDto>> GetChatMessagesAsync(int chatId)
        {
            return await _httpClient.GetFromJsonAsync<List<MessageResponseDto>>(
                $"api/chat/{chatId}/messages");
        }

        public async Task<ChatInfoDto> CreateChatAsync(CreateChatDto chatDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/chat", chatDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ChatInfoDto>();
        }*/
    }
}
