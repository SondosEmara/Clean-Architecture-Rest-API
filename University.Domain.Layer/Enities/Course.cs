using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Domain.Layer.Enities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public decimal Duration { get; set; }
        public ICollection<StudentEnrollment> StudentCourses { get; set; } = null!;
        public ICollection<DepartmentCourse> DepartmentCourse {  get; set; } = null!;   
    }
}
