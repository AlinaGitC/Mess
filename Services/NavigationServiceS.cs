using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppClient.Services
{
    public interface INavigationService
    {
        void NavigateTo<T>() where T : Window;
        void ShowDialog<T>() where T : Window;
        void CloseCurrent();
    }

    public class NavigationServiceS : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationServiceS(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<T>() where T : Window
        {
            var currentWindow = Application.Current.Windows.OfType<Window>()
                                  .FirstOrDefault(w => w.IsActive);
            var newWindow = _serviceProvider.GetRequiredService<T>();
            newWindow.Show();
            currentWindow?.Close();
        }

        public void ShowDialog<T>() where T : Window
        {
            var window = _serviceProvider.GetRequiredService<T>();
            window.ShowDialog();
        }

        public void CloseCurrent()
        {
            Application.Current.Windows.OfType<Window>()
                .FirstOrDefault(w => w.IsActive)?.Close();
        }
    }
}
