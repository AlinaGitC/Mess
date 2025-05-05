using AppClient.Views.ChatClient;
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

namespace AppClient.Views
{
    /// <summary>
    /// Логика взаимодействия для MainClientPage.xaml
    /// </summary>
    public partial class MainClientPage : Page
    {
        public static MainClientPage Instance { get; private set; }

        public MainClientPage()
        {
            Instance = this;
            InitializeComponent();
            FrameChats.Navigate(new GroupsFramePage());
            ChatFrame.Navigate(new ChatPage());

        }
    }
}
