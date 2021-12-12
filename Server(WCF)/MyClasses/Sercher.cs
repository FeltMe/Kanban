using Bullshit.Db;
using Server_WCF_.Db;
using Server_WCF_.MyClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_WCF_
{
    public class Sercher
    {
        public bool Serch(User user, Project project)
        {
            using (MyAccounst accounst = new MyAccounst())
            {
                var teams = accounst.Projects.Include("UsersInProject").ToList();
                foreach (var item in accounst.Users)
                {
                    if (item.Login == user.Login
                        && item.Password == user.Password
                        && item.CurrentProject.Id == project.Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public ObservableCollection<UserViewClass> SerchUsersForView(int ProjectId)
        {
            ObservableCollection<UserViewClass> datas = new ObservableCollection<UserViewClass>();
            using (MyAccounst accounst = new MyAccounst())
            {
                var teams = accounst.Projects.Include("UsersInProject").ToList();

                foreach (var item in accounst.Users)
                {
                    if(item.CurrentProject.Id == ProjectId)
                    {
                        datas.Add(new UserViewClass() { User = item.Login, Status = "Test Status" });
                    }
                }
            }
            return datas;
        }
    }
}
