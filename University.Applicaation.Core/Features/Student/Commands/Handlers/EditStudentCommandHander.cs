using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Interfaces;
using University.Application.Layer.Features.Students.Commands.Models;
using University.Application.Layer.Services.Students.Interface;
using University.Applicaation.Core.Common.Bases;
using University.Domain.Layer.Enities;

namespace University.Applicaation.Core.Features.Student.Commands.Handlers
{
    public class EditStudentCommandHander : IRequestHandler<EditStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;

        public EditStudentCommandHander(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var ifSuccess =await _studentService.EditAsync(request.EditStudentDto);

            if (ifSuccess) return ResponseHandler.Success("Suucess Edit");
            return ResponseHandler.Failed("Fail Edit");
        }
    }
}
