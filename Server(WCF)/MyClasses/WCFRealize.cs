using Bullshit.Db;
using Server_WCF_.Db;
using Server_WCF_.Intrfase;
using Server_WCF_.MyClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server_WCF_
{
    public class WCFRealize : IWcfInterface
    {
        public bool WriteToDbOneUser(User user) //todo
        {
            RegisterClass register = new RegisterClass();
            if (register.AddNewUser(user))
            {
                return true;
            }
            else return false;
        }

        public User ReadFromDbOneUser()
        {
            return null; //todo
        }

        public User RetrunCurentStateOfProject(int IdOfProject)
        {
            return null; // todo
        }

        public ObservableCollection<UserViewClass> ReturnAllUsersForChat(int IdOfProject)
        {
            Sercher sercher = new Sercher();
            var datas = sercher.SerchUsersForView(IdOfProject);
            return datas;
        }

        public bool IsLogined(User user, Project project)
        {
            Console.WriteLine(user.Login);
            Sercher sercher = new Sercher();
            if (sercher.Serch(user, project))
                return true;
            else return false;
        }

        public void Logging(Logirovanie logirovanie)
        {
            try
            {
                using (MyAccounst accounst = new MyAccounst())
                {
                    accounst.Logging.Add(logirovanie);
                    accounst.SaveChanges();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Eror while loggining " + logirovanie.UserLogin);
            }
        }

        public Project ReturnProjectWithCurrentId(int Id)
        {
            using (MyAccounst accounst = new MyAccounst())
            {
                foreach (var item in accounst.Projects)
                {
                    if(item.Id == Id)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
    }
}
