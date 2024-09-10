using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Services.Interfaces;
using University.Domain.Layer.Enities;
using University.Presentaion.Contracts.Features.Students.Queries.Models;

namespace University.Presentaion.Contracts.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly IStudentService _studentService;
        public StudentQueryHandler(IStudentService studentService)=>_studentService = studentService;
        public async Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            //request not have input data 
            return await  _studentService.GetAllStudents();
            //Still here check the response output () and make response class and mapper...........!
        }
    }
}
