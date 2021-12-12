using System.Windows;
using Bullshit.ServiceReference1;

namespace Bullshit
{
	public partial class Coon : Window
    {
        public Coon()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (WcfInterfaceClient wcf = new WcfInterfaceClient())
            {
                User user = new User()
                {
                    Login = "q",
                    Password = "q",
                    Gmail = "q",
                    Right = false,
                    CurrentProject = wcf.ReturnProjectWithCurrentId(1),
                };
                wcf.WriteToDbOneUser(user);
            }

        }
    }
}
