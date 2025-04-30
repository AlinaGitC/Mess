//using AppClient.Services;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using AppClient.Services;
using AppClient.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AppClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<AutorisationWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрация сервисов
            services.AddSingleton<ApiService>(_ =>
                new ApiService("https://ваш-сервер.com"));
            services.AddSingleton<ChatService>();
            services.AddSingleton<INavigationService, NavigationServiceS>();

            // Регистрация ViewModels
            services.AddTransient<LoginViewModel>();
            services.AddTransient<MainClientViewModel>();
            services.AddTransient<RegistrationViewModel>();

            // Регистрация окон
            services.AddTransient<AutorisationWindow>();
            services.AddTransient<MainClientWindow>();
            services.AddTransient<RegistrationWindow>();
        }
    }

}
