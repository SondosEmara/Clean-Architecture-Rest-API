using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Services.Interfaces;
using University.Presentaion.Contracts.Bases;
using University.Presentaion.Contracts.Features.Students.Commands.Models;

namespace University.Presentaion.Contracts.Features.Students.Commands.Handlers
{
    //public class StudentCommandHandler : IRequestHandler<AddStudentCommand, Response<bool>>
    //{
    //    private readonly IStudentService _studentService;
    //    private readonly IMapper _mapper;

    //    public StudentCommandHandler(IStudentService studentService, IMapper mapper)
    //    {
    //        _studentService = studentService;
    //        _mapper = mapper;
    //    } 


    //    //public async Task<Response<bool>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    //    //{
    //    //    //Map Request to Studnet
    //    //    var newStudent =_mapper.Map<Student>(request);
    //    //    var result=await _studentService.AddAsync(newStudent);

    //    //    //if (result==true) return true;
    //    //    //else return BadRequest<string>();
    //    //}
    //}
}
