using AutoMapper;
using MediatR;
using University.Applicaation.Core.Common.Bases;
using University.Applicaation.Core.Features.Students.Queries.Models;
using University.Application.Layer.Services.Students.Interface;
using University.Application.Layer.Services.Students.Result;

namespace University.Applicaation.Core.Features.Students.Queries.Handlers
{
    public class GetSingleStudentQueryHandler : IRequestHandler<GetSingleStudentQuery, Response<GetSingleStudentResponse>>
    {
        private readonly IStudentService _studentService;

        public GetSingleStudentQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<Response<GetSingleStudentResponse>> Handle(GetSingleStudentQuery request, CancellationToken cancellationToken)
        {
            if (request.id == null) return ResponseHandler.Failed<GetSingleStudentResponse>();
            try
            {
                var reseult = await _studentService.GetStudentById((int)request.id);
                if (reseult != null) return ResponseHandler.Success(reseult);
                return ResponseHandler.Failed<GetSingleStudentResponse>();
            }
            catch (Exception ex)
            {
                return ResponseHandler.FaildException<GetSingleStudentResponse>(ex);
            }
        }
    }
}
