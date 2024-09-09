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
    internal struct StudentEnrollmentConfig : IEntityTypeConfiguration<StudentEnrollment>
    {
        public void Configure(EntityTypeBuilder<StudentEnrollment> builder)
        { 
            //Change to the StudentEnrollyments in DB.
            builder.ToTable("StudentEnrollments");

            //Config Composite PrimaryKey.
            builder.HasKey(enrollyemnt => new { enrollyemnt.CourseId, enrollyemnt.StudentId });
        }
    }
}
