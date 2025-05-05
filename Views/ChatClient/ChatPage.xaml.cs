using AppClient.Models;
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
    /// Логика взаимодействия для ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        private const string HintText = "Написать сообщение...";
        public ChatPage()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MessageTextBox.Text) && MessageTextBox.Text != HintText)
            {
                //Логика отправки сообщения
                MessageTextBox.Text = HintText;
            }
        }

        private void MessageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MessageTextBox.Text))
            {
                MessageTextBox.Text = HintText;
                MessageTextBox.Foreground = Brushes.Gray;
                MessageTextBox.FontStyle = FontStyles.Italic;
            }
        }

        private void MessageTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MessageTextBox.Text == HintText)
            {
                MessageTextBox.Text = "";
                MessageTextBox.Foreground = Brushes.Black;
                MessageTextBox.FontStyle = FontStyles.Normal;
            }
        }
        
        private void ScrollToEnd()
        {
            if (MessagesList.Items.Count > 0)
            {
                var lastItem = MessagesList.Items[MessagesList.Items.Count - 1];
                MessagesList.ScrollIntoView(lastItem);

                // Альтернативный вариант для ItemsControl
                var scrollViewer = FindVisualChild<ScrollViewer>(MessagesList);
                scrollViewer?.ScrollToEnd();
            }
        }
        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var child = VisualTreeHelper.GetChild(obj, i);
                if (child is T result)
                    return result;
                var childResult = FindVisualChild<T>(child);
                if (childResult != null)
                    return childResult;
            }
            return null;
        }
    }
}
