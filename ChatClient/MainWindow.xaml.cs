using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
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

namespace ChatClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Polling Button
            OpenChatWindow(new PollingChatHandler(tbAdress.Text + "/PollingChat", tbUsername.Text, 
                TimeSpan.FromMilliseconds(1000)));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Two-Way Button
            btPolling.IsEnabled = false;
            btTwoWay.IsEnabled = false;
            OpenChatWindow(new TwoWayChatHandler(tbAdress.Text + "/Chat", tbUsername.Text));
        }

        private void OpenChatWindow(ChatServiceHandler handler)
        {
            var chatWindow = new ChatWindow(handler);
            chatWindow.Show();
            Close();
            chatWindow.Focus();
        }
    }
}
