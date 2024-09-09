using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Domain.Layer.Enities
{
    public class DepartmentCourse
    {
        public int DepartmentId {  get; set; }
        public Department Department { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
