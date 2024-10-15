using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enums;

namespace University.Application.Layer.Services.Students.DTO
{
    public record AddStudentDto
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public StudentLevel Level { get; set; }
    }
}
