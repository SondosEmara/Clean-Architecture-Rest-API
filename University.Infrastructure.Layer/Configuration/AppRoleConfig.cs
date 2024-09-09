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
    internal class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("Roles");

            builder.Property(role => role.Name)
                   .HasMaxLength(100)
                   .IsRequired(true);

            builder.HasMany(role => role.AppUsersRoles)
                   .WithOne(userRole => userRole.Role)
                   .HasForeignKey(role => role.RoleId)
                   .IsRequired(true);
        }
    }
}
