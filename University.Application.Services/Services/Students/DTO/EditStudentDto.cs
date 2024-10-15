using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Layer.Services.Students.DTO
{
    public record EditStudentDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
