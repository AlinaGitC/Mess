using AppClient.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppClient.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly ApiService _apiService;
        private readonly INavigationService _navigation;

        [ObservableProperty]
        private string _login;

        [ObservableProperty]
        private string _password;

        public IRelayCommand LoginCommand { get; }
        public IRelayCommand RegisterCommand { get; }

        public LoginViewModel(ApiService apiService, INavigationService navigation)
        {
            _apiService = apiService;
            _navigation = navigation;

            LoginCommand = new RelayCommand(OnLogin);
            RegisterCommand = new RelayCommand(OnRegister);
        }

        private async void OnLogin()
        {
            try
            {
                await _apiService.LoginAsync(Login, Password);
                _navigation.NavigateTo<MainClientWindow>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnRegister()
        {
            _navigation.NavigateTo<RegistrationWindow>();
        }
    }
}
