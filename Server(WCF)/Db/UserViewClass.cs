using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server_WCF_.MyClasses
{
    [DataContract]
    public class UserViewClass
    {
        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
