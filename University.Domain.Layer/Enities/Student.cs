using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enums;

namespace University.Domain.Layer.Enities
{
    public class Student:AppUser
    {
        public StudentLevel Level { get; set; }
        public ICollection<StudentEnrollment> StudentCourses { get; set; } = null!;
    }
}
