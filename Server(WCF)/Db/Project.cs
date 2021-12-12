using Bullshit.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server_WCF_.Db
{
    [DataContract]
    public class Project
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string ProjectName { get; set; }

        [DataMember]
        public List<User> UsersInProject { get; set; }

    }
}
