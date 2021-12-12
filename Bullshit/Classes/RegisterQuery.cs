using Bullshit.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bullshit.Classes
{
    public class RegisterQuery
    {
        public MyEncipher Enc { get; set; } = new MyEncipher();

        public bool AddNewUser(User user)
        {
            WcfInterfaceClient wcf = new WcfInterfaceClient();
            try
            {
                if (wcf.WriteToDbOneUser(user))
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Eror while registration");
                return false;
            }
        }
    }
}
