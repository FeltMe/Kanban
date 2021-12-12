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
