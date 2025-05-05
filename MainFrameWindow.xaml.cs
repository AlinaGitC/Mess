using AppClient.Views;
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
using System.Windows.Shapes;

namespace AppClient
{
    /// <summary>
    /// Логика взаимодействия для MainFrameWindow.xaml
    /// </summary>
    public partial class MainFrameWindow : Window
    {
        public static MainFrameWindow Instance { get; private set; }
        public MainFrameWindow()
        {
            Instance = this;
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            MainFrame.Navigate(new MainClientPage());
        }
    }
}
