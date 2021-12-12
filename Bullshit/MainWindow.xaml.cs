using Bullshit.ServiceReference1;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Bullshit
{

	public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {

        private const int Grid_row = 1;
        private const int Grid_col = 1;
        private const int Grid_row_span = 6;


        public User CurrentUser { get; set; }
        public Project CurrentProject { get; set; }

        private CanbanControle canban = new CanbanControle();
        private UserChat chat = new UserChat();
        


        public MainWindow()
        {
            InitializeComponent();
            AddComponentToWokSpace(canban, Visibility.Visible, CurrentUser);
            AddComponentToWokSpace(chat, Visibility.Hidden, CurrentUser);
        }

        private void AddComponentToWokSpace(UserControl control, Visibility visibility, User user)
        {
            control.Visibility = visibility;
            if (control is CanbanControle)
            {
                (control as CanbanControle).User = user;
            }
            else (control as UserChat).Currentuser = user;
            Grid.SetRow(control, Grid_row);
            Grid.SetColumn(control, Grid_col);
            Grid.SetRowSpan(control, Grid_row_span);
            MyMainGrid.Children.Add(control);
        }

        private void TeamTasksClick(object sender, RoutedEventArgs e)
        {
            Visible(canban, chat);
        }

        private void ChatOpenClick(object sender, RoutedEventArgs e)
        {
            Visible(chat, canban);
            chat.Currentuser = CurrentUser;
        }

        private void Visible(UserControl ToVisible, UserControl ToHide)
        {
            ToVisible.Visibility = Visibility.Visible;
            ToHide.Visibility = Visibility.Hidden;
        }

        private void MenuMeEnter(object sender, MouseEventArgs e)
        {
            UserName.Text = CurrentUser.Login;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(3000);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
        }

    }
}