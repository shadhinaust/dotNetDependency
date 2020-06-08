using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RestApi.Model.Map
{
    public class RoleMap: EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable("role")
               .HasKey(role => role.Id);

            this.Property(role => role.Id)
                .HasColumnName("id")
                .HasColumnType("smallint");

            this.Property(role => role.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();

            this.Property(role => role.Description)
                .HasColumnName("description")
                .HasColumnType("nvarchar")
                .HasMaxLength(128);

            this.Property(role => role.Status)
                .HasColumnName("status")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}