using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppClient.Views.ChatClient
{
    /// <summary>
    /// Логика взаимодействия для GroupsFramePage.xaml
    /// </summary>
    public partial class GroupsFramePage : Page
    {
        private Button _selectedChatButton;
        public GroupsFramePage()
        {
            InitializeComponent();
        }
        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            // Снимаем выделение с предыдущего выбранного чата
            if (_selectedChatButton != null)
            {
                _selectedChatButton.Style = (Style)FindResource("ChatItemButtonStyle");
            }

            // Устанавливаем выделение для нового выбранного чата
            _selectedChatButton = (Button)sender;
            _selectedChatButton.Style = (Style)FindResource("SelectedChatItemStyle");
            if (_selectedChatButton != null)
            {
                _selectedChatButton.Style = (Style)FindResource("ChatItemButtonStyle");
            }

            _selectedChatButton = (Button)sender;
            _selectedChatButton.Style = (Style)FindResource("SelectedChatItemStyle");

            // Здесь можно добавить логику для отображения выбранного чата
            string chatName = ((TextBlock)((StackPanel)_selectedChatButton.Content).Children[0]).Text;
            // MessageBox.Show($"Выбран чат: {chatName}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ToggleSection_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string contentName = button.Tag.ToString();
            StackPanel content = (StackPanel)FindName(contentName);
            var arrow = (Path)button.Template.FindName("arrow", button);
            if (content.Visibility == Visibility.Collapsed)
            {
                content.Visibility = Visibility.Visible;
                arrow.Data = Geometry.Parse("M 0,0 L 10,5 L 0,10 Z"); // Стрелка вправо
            }
            else
            {
                content.Visibility = Visibility.Collapsed;
                arrow.Data = Geometry.Parse("M 0,5 L 10,5 L 5,10 Z"); // Стрелка вниз
            }
        }
    }
}
