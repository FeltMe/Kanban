using Bullshit.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullshit.Classes
{
    public class SendLogirovanieData
    {
        public void Send(string login, int id, DateTime time)
        {
            using (WcfInterfaceClient client = new WcfInterfaceClient())
            {
                ServiceReference1.Logirovanie logirovanie = new Logirovanie()
                {
                    UserLogin = login,
                    ProjectId = id,
                    TimeLogining = time
                };
                client.Logging(logirovanie);
            }
        }
    }
}
