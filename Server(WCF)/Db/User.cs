using Server_WCF_.Db;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Bullshit.Db
{
	[DataContract]
    public class User
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required] // provide Nut NULL
        public string Login { get; set; }

        [DataMember]
        [Required]
        public string Password { get; set; }

        [DataMember]
        [Required]
        public bool Right { get; set; } // 0-User, 1-Admin

        [DataMember]
        [Required]
        public string Gmail { get; set; }

        [DataMember]
        [Required]
        public Project CurrentProject { get; set; }
    }
}
