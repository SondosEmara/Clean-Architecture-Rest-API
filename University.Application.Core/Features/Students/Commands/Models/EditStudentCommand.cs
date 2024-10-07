using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;
using University.Presentaion.Contracts.Bases;

namespace University.Presentaion.Contracts.Features.Students.Commands.Models
{
    public record EditStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
