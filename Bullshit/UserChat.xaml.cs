using Bullshit.ServiceReference1;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Bullshit
{
	public partial class UserChat : UserControl
    {
        public User Currentuser { get; set; }

        public ObservableCollection<ServiceReference1.UserViewClass> UserViews { get; set; } = new ObservableCollection<ServiceReference1.UserViewClass>();

        public UserChat()
        {
            InitializeComponent();
            UserViewChat.ItemsSource = UserViews;
            UserViewChat.Foreground = Brushes.Blue;
        }

        private void SendClick(object sender, RoutedEventArgs e)
        {
            ReadMsg(TextToSend.Text);
        }

        private void ReadMsg(string text)
        {
            if (string.IsNullOrEmpty(text) != true)
            {
                TextToSend.Clear();
                ChatTextBox.Document.Blocks.Add(new Paragraph(new Run(Currentuser.Login + ": " + text)));
            }
        }

        public void AddingUsersToView()
        {
            using (ServiceReference1.WcfInterfaceClient client = new WcfInterfaceClient())
            {
                var Data = client.ReturnAllUsersForChat(Currentuser.CurrentProject.Id);
                UserViews.Clear();
                foreach (var item in Data as UserViewClass[])
                {
                    UserViews.Add(item);
                }
            }
        }

        private void LoadUsers(object sender, RoutedEventArgs e)
        {
            AddingUsersToView();
        }
    }
}
