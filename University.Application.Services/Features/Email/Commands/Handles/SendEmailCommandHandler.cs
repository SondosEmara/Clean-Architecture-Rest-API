using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;
using University.Application.Layer.Features.Email.Commands.Models;
using University.Application.Layer.Services.Interfaces;

namespace University.Application.Layer.Features.Email.Commands.Handles
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, Response<string>>
    {
        private readonly IEmaillService _emaillService;
        public SendEmailCommandHandler(IEmaillService emaillService)
        {
            _emaillService = emaillService;
        }
        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
           return ResponseHandler.Success(await _emaillService.SendEmailAsync(request.Email,request.Message));
        }
    }
}
