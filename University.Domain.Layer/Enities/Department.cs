using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Domain.Layer.Enities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<DepartmentCourse> DepartmentCourse { get; set; } = null!;
    }
}
