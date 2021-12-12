using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Net.Sockets;
using System.Net;
using Bullshit.Db;
using Server_WCF_.Db;

namespace Server_WCF_
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(WCFRealize));
            host.Open();
            Console.WriteLine("WCF Service Started");


            Console.ReadLine();
        }

        static private void ccc()
        {
            using (MyAccounst q = new MyAccounst())
            {
                Project a = new Project()
                {
                    ProjectName = "Tmp"
                };
                User b = new User()
                {
                    Login = "1",
                    Password = "1",
                    CurrentProject = a,
                    Gmail = "1",
                    Right = false,
                    
                };
                q.Projects.Add(a);
                q.Users.Add(b);
                q.SaveChanges();
            }
        }
    }
}
