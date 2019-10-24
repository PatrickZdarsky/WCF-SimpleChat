using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ChatLib;

namespace ChatClient
{
    /// <summary>
    /// Interaktionslogik für ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public ChatServiceHandler ChatServiceHandler;
        
        public ChatWindow(ChatServiceHandler handler)
        {
            InitializeComponent();
            ChatServiceHandler = handler;
            ChatServiceHandler.Window = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChatServiceHandler.Connect();
        }

        private void TbChatInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var chatMessage = new ChatMessage()
                {
                    DateTime = DateTime.Now,
                    Message = ((TextBox)sender).Text,
                    UserName = ChatServiceHandler.UserName
                };
                ChatServiceHandler.SendMessage(chatMessage);
                Debug.WriteLine("Message sent");
            }
        }
    }
}
