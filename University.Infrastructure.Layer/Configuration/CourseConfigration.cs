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
    internal struct CourseConfigration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            //Change Course to Courses in DB
            builder.ToTable("Courses");

            //One-M between Course--StudentEnrollyment
            builder.HasMany(course => course.StudentCourses)
                   .WithOne(studCourse => studCourse.Course)
                   .HasForeignKey(studCourse => studCourse.CourseId)
                   .IsRequired(true);

            //One-M between Course -- DeptCourse
            builder.HasMany(course => course.DepartmentCourse)
                   .WithOne(deptCourse => deptCourse.Course)
                   .HasForeignKey(deptCourse => deptCourse.DepartmentId)
                   .IsRequired(true);


            //Properties Config
            builder.Property(crs => crs.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(crs => crs.Description).HasMaxLength(100).IsRequired(true);
            builder.Property(crs => crs.Duration).HasColumnType("decimal(30,2)");
        }
    }
}
