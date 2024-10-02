using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;
using University.Domain.Layer.Enums;
using University.Presentaion.Contracts.Bases;

namespace University.Presentaion.Contracts.Features.Students.Commands.Models
{
    //That DTO The enter in the Api Input,In the futute add the IAuthoriztionRequest.......
    public record AddStudentCommand:IRequest<Response<string>>
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public StudentLevel Level { get; set; }
    }
}
