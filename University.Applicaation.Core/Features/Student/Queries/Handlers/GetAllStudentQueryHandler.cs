using AutoMapper;
using MediatR;
using University.Applicaation.Core.Common.Bases;
using University.Applicaation.Core.Features.Students.Queries.Models;
using University.Application.Layer.Services.Students.Interface;
using University.Application.Layer.Services.Students.Result;


namespace University.Applicaation.Core.Students.Queries.Handlers
{
    public sealed class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentsQuery, Response<List<GetStudentListResponse>>>
    {
        private readonly IStudentService _studentService;

        public GetAllStudentQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
      
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result =await _studentService.GetAllStudents();
                if (result != null) return ResponseHandler.Success(result);
                return ResponseHandler.Failed<List<GetStudentListResponse>>();
            }
            catch (Exception ex) 
            {
               return ResponseHandler.FaildException<List<GetStudentListResponse>>(ex);
            }
         }
       
    }
}
