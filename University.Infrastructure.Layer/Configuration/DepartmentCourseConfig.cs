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
    internal struct DepartmentCourseConfig : IEntityTypeConfiguration<DepartmentCourse>
    {
        public void Configure(EntityTypeBuilder<DepartmentCourse> builder)
        {
            builder.ToTable("DepartmentCourses");

            builder.HasKey(deptCrs => new {deptCrs.CourseId,deptCrs.DepartmentId});
        }
    }
}
