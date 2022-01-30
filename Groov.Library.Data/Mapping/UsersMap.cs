using Groov.Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groov.Library.Data.Mapping
{
    public class UsersMap : EntityTypeConfiguration<User>
    {
        public UsersMap()
        {
            this.Property(t => t.Name).HasMaxLength(50);
            this.Property(t => t.UserName).HasMaxLength(100);
            this.Property(t => t.Password).HasMaxLength(50);
            this.Property(t => t.Email).HasMaxLength(100);
            this.Property(t => t.City).HasMaxLength(50);
            this.Property(t => t.Biography).HasMaxLength(200);

            this.ToTable("Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.Register_Date).HasColumnName("Register_Date");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Biography).HasColumnName("Biography");


        }
    }
}
