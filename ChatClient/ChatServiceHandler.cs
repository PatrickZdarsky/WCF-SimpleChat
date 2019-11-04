using ChatLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChatClient
{
    public abstract class ChatServiceHandler
    {
        public ChatWindow Window { get; set; }
        protected string address;
        public string UserName { get; private set; }
        protected bool loaded = false;

        protected ChatServiceHandler(string address, string userName)
        {
            this.address = address;
            this.UserName = userName;
        }

        public void Connect()
        {
            try
            {
                Open();
                loaded = true;
            }
            catch (Exception e)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                Window.Close();
                mainWindow.Focus();
            }
        }

        protected abstract void Open();

        public abstract void SendMessage(ChatMessage chatMessage);

        protected virtual void AddMessage(ChatMessage chatMessage)
        {
           // chatMessage.UserName = userName;

            Window.Dispatcher.Invoke(() =>
            {
                var label = new Label();
                if (chatMessage.Message != null)
                    label.Content = chatMessage.DateTime + " " + chatMessage.UserName + " > " + chatMessage.Message;
                else
                    label.Content = chatMessage.DateTime + " " + chatMessage.UserName + " ist dem Chat beigetreten!"; 

                if (chatMessage.UserName == UserName)
                    label.Foreground = Brushes.Gray;

                Window.chatStackPanel.Children.Add(label);
                if (Window.chatStackPanel.Children.Count > 100)
                    Window.chatStackPanel.Children.RemoveAt(0);

                Window.scrollViewer.ScrollToEnd();
            });
        }
    }
}
