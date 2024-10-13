using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;
using University.Domain.Layer.Enities;
using University.Domain.Layer.Enums;

namespace University.Application.Layer.Features.User.Commands.Models
{
    public class AddUserCommand:IRequest<Response<String>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword {  get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
    }
}
