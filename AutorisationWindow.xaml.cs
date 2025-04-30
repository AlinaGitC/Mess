using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AutorisationWindow : Window
    {
        public AutorisationWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
           new MainClientWindow().Show();
           this.Close();
        }

        private void RegisrtButton_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            this.Close();
        }
    }
}