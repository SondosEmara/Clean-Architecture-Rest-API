using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;

namespace University.Infrastructure.Layer.Configuration
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable(name: "Users");

            builder.Property(user=>user.UserName)
                   .HasMaxLength(50)
                   .IsRequired(true);

            builder.HasMany(user => user.AppUserRoles)
                   .WithOne(userRole => userRole.User)
                   .HasForeignKey(userRole => userRole.UserId)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.Restrict);

            //Store the Value as String not int number
            builder.Property(p => p.Gender)
                   .HasConversion<string>();

        }
    }
}
