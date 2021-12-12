using System;
using System.Windows;
using Bullshit.ServiceReference1;
using Bullshit.Classes;

namespace Bullshit
{
	public partial class LoginWindow : MahApps.Metro.Controls.MetroWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Login();
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
        }

        private void Login()
        {
            AcceptLoginWCFData datas = new AcceptLoginWCFData();

            User user = new User();
            Project project = new Project();

            if (datas.CheckIn(UsernameTextBox.Text, UserPasswordBox.Password,
                Int32.Parse(IdProjectBox.Text), ref user, ref project))
            {
                Logining(user.Login, project.Id, DateTime.Now);
                MainWindow window = new MainWindow
                {
                    CurrentUser = user,
                    CurrentProject = project
                };
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error while Login in");
            }
        }

        private void Logining(string login, int projId, DateTime time)
        {
            SendLogirovanieData Sender = new SendLogirovanieData();
            Sender.Send(login, projId, DateTime.Now);
        }

        private void SignUpClick(object sender, RoutedEventArgs e)
        {
            RegisterWindow window = new RegisterWindow();
            window.Show();
            this.Close();
        }

        private void JoinClick(object sender, RoutedEventArgs e)
        {
            Coon coon = new Coon();
            coon.ShowDialog();
        }
    }
}



