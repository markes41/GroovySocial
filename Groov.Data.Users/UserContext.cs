using Groov.Data.Base.Base;
using Groov.Data.Users.Entities;
using Groov.Data.Users.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groov.Data.Users
{
    public class UserContext : DbContext
    {
        private string ConnectionString
        {
            get { return "Server=DESKTOP-32A232I\\SQLEXPRESS;Database=Home;User Id=sa;Password=1234;"; }
        }

        public UserContext()
        {
            this.Database.Connection.ConnectionString = this.ConnectionString;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UsersMap());
        }


    }
}
