using AutoMapper;
using MediatR;
using University.Applicaation.Core.Common.Bases;
using University.Application.Layer.Services.Students.Interface;
using University.Applicaation.Core.Features.Student.Commands.Models;


namespace UUniversity.Applicaation.Core.Features.Student.Commands.Handlers
{
    public sealed class CreateStudentCommandHandler : IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;

        public CreateStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var result=await _studentService.AddAsync(request.StudentDto);
            if (result == true) return ResponseHandler.Success("Added Succefully....");
            return ResponseHandler.Failed("No Added Succesfuly..");
        }
    }
}
