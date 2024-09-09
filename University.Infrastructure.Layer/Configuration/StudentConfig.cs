using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;
using University.Domain.Layer.Enums;

namespace University.Infrastructure.Layer.Configuration
{
    internal struct StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasMany(stud => stud.StudentCourses)
                   .WithOne(studCourse => studCourse.Student)
                   .HasForeignKey(studCourse => studCourse.StudentId)
                   .IsRequired(true);


            builder.Property(stud => stud.Level)
                   .HasConversion(
                       level => level.ToString(),
                       level => (StudentLevel)Enum.Parse(typeof(StudentLevel), level)
                    );
        }
    }
}
