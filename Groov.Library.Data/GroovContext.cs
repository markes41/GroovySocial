using Groov.Library.Data.Entities;
using Groov.Library.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groov.Library.Data
{
    public class GroovContext : DbContext
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source=DESKTOP-32A232I\\SQLEXPRESS;database=GroovySocial;User Id=sa;Password=1234;Persist Security Info=True;";
            }
        }

        public GroovContext() 
            : base()
        {
            this.Database.Connection.ConnectionString = this.ConnectionString;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsersMap());
        }
    }
}
