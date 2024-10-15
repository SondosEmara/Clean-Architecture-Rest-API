using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Services.Students.DTO;
using University.Applicaation.Core.Common.Bases;


namespace University.Applicaation.Core.Features.Student.Commands.Models
{
    //That DTO The enter in the Api Input,In the futute add the IAuthoriztionRequest.......
    public record AddStudentCommand : IRequest<Response<string>>
    {
        public AddStudentDto StudentDto { get; set; } = null!;
    }
}
