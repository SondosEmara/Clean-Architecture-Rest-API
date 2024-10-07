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
    public class EditStudentCommandHander : IRequestHandler<EditStudentCommand, Response<string>>
    {
        private readonly IStudentRepositry _studentRepositry;
        private readonly IMapper _mapper;
        public EditStudentCommandHander(IStudentRepositry studentRepositry, IMapper mapper)
        {
            _studentRepositry = studentRepositry;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepositry.GetByIdAsync(request.Id);
            if (student == null) return ResponseHandler.Failed("Not Exist..........!");
            var mappedStudent = _mapper.Map<Student>(request);

            var ifSuccess = await _studentRepositry.UpdateAsync(mappedStudent);

            if (ifSuccess) return ResponseHandler.Success("Suucess Edit");
            return ResponseHandler.Failed("Fail Edit");
        }
    }
}
