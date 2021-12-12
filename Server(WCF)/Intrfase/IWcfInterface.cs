using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Bullshit.Db;
using Server_WCF_.Db;
using Server_WCF_.MyClasses;
using System.Collections.ObjectModel;

namespace Server_WCF_.Intrfase
{
    [ServiceContract]
    public interface IWcfInterface
    {
        [OperationContract]
        bool WriteToDbOneUser(User User);

        [OperationContract]
        User ReadFromDbOneUser();

        [OperationContract]
        User RetrunCurentStateOfProject(int ProjectId); // Return to user full state of project + return state of tasks

        [OperationContract]
        bool IsLogined(User user, Project project);

        [OperationContract]
        ObservableCollection<UserViewClass> ReturnAllUsersForChat(int IdOfProject);

        [OperationContract]
        void Logging(Logirovanie logirovanie);

        [OperationContract]
        Project ReturnProjectWithCurrentId(int Id);
    }
}
