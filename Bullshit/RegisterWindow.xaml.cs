using Bullshit.Classes;
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

namespace Bullshit
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class RegisterWindow : MahApps.Metro.Controls.MetroWindow
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            Register();
        }

        private void Register()
        {
            RegisterQuery query = new RegisterQuery();

            ServiceReference1.WcfInterfaceClient client = new ServiceReference1.WcfInterfaceClient();
            ServiceReference1.User user = new ServiceReference1.User
            {
                Login = LoginBox.Text,
                Password = PasswordBox.Password,
                Right = false,
                Gmail = GmailBox.Text,
            };

            if (query.AddNewUser(user))
            {
                MainWindow window = new MainWindow
                {
                    CurrentUser = user,
                    CurrentProject = user.CurrentProject
                };
                window.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Ne ok");
        }

        private void WindowClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
