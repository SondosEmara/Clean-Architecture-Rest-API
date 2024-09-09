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
    internal struct DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //Change the table name in db
            builder.ToTable("Departments");

            //Relation one-Many
            builder.HasMany(dept => dept.DepartmentCourse)
                   .WithOne(deptCrs => deptCrs.Department)
                   .HasForeignKey(deptCrs => deptCrs.DepartmentId)
                   .IsRequired(true);


            //Property Setting
            builder.Property(dept => dept.Name)
                   .HasMaxLength(50)
                   .IsRequired(true);

        }
    }
}
