using Bullshit.Db;
using Server_WCF_.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Server_WCF_.MyClasses
{
    public class RegisterClass
    {
        public bool AddNewUser(User user)
        {
            using (MyAccounst myAccounst = new MyAccounst())
            {
                try
                {
                    foreach (var item in myAccounst.Users)
                    {
                        if (item.Login == user.Login)
                        {
                            return false;
                        }
                    }
                    myAccounst.Users.Add(user);
                    myAccounst.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }
    }
}
