using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server_WCF_.Db
{
    [DataContract]
    public class Logirovanie
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string UserLogin { get; set; }

        [DataMember]
        [Required]
        public int ProjectId { get; set; }

        [DataMember]
        [Required]
        public DateTime TimeLogining { get; set; }
    }
}
