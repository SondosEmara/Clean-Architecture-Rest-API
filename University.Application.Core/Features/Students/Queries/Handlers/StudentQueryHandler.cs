using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Services.Interfaces;
using University.Domain.Layer.Enities;
using University.Presentaion.Contracts.Bases;
using University.Presentaion.Contracts.Features.Students.Queries.Models;
using University.Presentaion.Contracts.Features.Students.Queries.Results;

namespace University.Presentaion.Contracts.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : IRequestHandler<GetAllStudentsQuery, Response<List<GetStudentListResponse>>>,
                                       IRequestHandler<GetSingleStudentQuery, Response<GetSingleStudentResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentQueryHandler(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper =mapper;
        }
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var studentList = await _studentService.GetAllStudents();
                var reseult = _mapper.Map<List<GetStudentListResponse>>(studentList);
                if (reseult != null) return ResponseHandler.Success(reseult);
                return ResponseHandler.Failed<List<GetStudentListResponse>>();
            }
            catch (Exception ex) 
            {
               return ResponseHandler.FaildException<List<GetStudentListResponse>>(ex);
            }
         }
        public async Task<Response<GetSingleStudentResponse>> Handle(GetSingleStudentQuery request, CancellationToken cancellationToken)
        {
            if (request.id == null) return ResponseHandler.Failed<GetSingleStudentResponse>();
            try
            {
                var targetStudent = await _studentService.GetStudentById(request.id.Value);
                var reseult = _mapper.Map<GetSingleStudentResponse>(targetStudent);
                if (reseult==null) return ResponseHandler.Success(reseult);
                return ResponseHandler.Failed<GetSingleStudentResponse>();
            }
            catch (Exception ex)
            {
                return ResponseHandler.FaildException< GetSingleStudentResponse> (ex);
            }
        }
    }
}
