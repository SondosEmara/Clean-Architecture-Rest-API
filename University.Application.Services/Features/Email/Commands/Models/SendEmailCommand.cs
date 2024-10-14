using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;

namespace University.Application.Layer.Features.Email.Commands.Models
{
    public record SendEmailCommand(string Email, string Message) : IRequest<Response<string>>;
}
