using Groov.Data.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groov.Data.Users.Mappings
{
    public class UsersMap : EntityTypeConfiguration<User>
    {
        public UsersMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName).HasMaxLength(50);
            this.Property(t => t.Password).HasMaxLength(50);

            this.ToTable("Usuarios");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("Username");
            this.Property(t => t.Password).HasColumnName("Password");

        }
    }
}
