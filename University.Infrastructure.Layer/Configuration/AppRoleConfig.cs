using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;

namespace University.Infrastructure.Layer.Configuration
{
    public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable(name:"Roles");

            builder.Property(role => role.Name)
                   .HasMaxLength(100)
                   .IsRequired(true);

            // This means that when a record in AspNetRoles or AspNetUsers is deleted, it will also delete related records in AspNetUserRoles.
            builder.HasMany(role => role.AppUsersRoles)
                   .WithOne(userRole => userRole.Role)
                   .HasForeignKey(role => role.RoleId)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
