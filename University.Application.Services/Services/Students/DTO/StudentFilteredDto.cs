using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Helpers;

namespace University.Application.Layer.Services.Students.DTO
{
    public record StudentFilteredDto
    {
        public string? SerachTerm { get; set; }
        public OrderStudentEnum? OrderBy { get; set; }
    }
}
