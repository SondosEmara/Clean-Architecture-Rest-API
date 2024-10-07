using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;
using University.Application.Layer.Common.Interfaces;
using University.Application.Layer.Features.Students.Commands.Models;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Features.Students.Commands.Handlers
{
    public sealed class CreateStudentCommandHandler : IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentRepositry _studentRepositry;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentRepositry studentRepositry, IMapper mapper)
        {
            _studentRepositry = studentRepositry;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var newStudent = _mapper.Map<Student>(request);
            var result = await _studentRepositry.AddAsync(newStudent);
            if (result == true) return ResponseHandler.Success("Added Succefully....");
            return ResponseHandler.Failed("No Added Succesfuly..");
        }
    }
}
