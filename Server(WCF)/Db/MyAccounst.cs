using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;
using Server_WCF_.Db;

namespace Bullshit.Db
{
    class MyAccounst : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Logirovanie> Logging { get; set; }

        public MyAccounst() : base(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString) {} 
    }
}
