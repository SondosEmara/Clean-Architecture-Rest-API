using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Domain.Layer.Enities
{ 
    public class StudentEnrollment
    {
        #region Variables
            public int StudentId { get; set; }
            public Student Student { get; set; } = null!;
            public int CourseId { get; set; }
            public Course Course { get; set; } = null!;

        #endregion

    }
}
