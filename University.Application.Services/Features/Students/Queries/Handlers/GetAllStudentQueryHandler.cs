using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;
using University.Application.Layer.Common.Interfaces;
using University.Application.Layer.Features.Students.Queries.Models;
using University.Application.Layer.Features.Students.Queries.Results;
using University.Application.Layer.Services.Interfaces;
using University.Domain.Layer.Enities;
using University.Presentaion.Contracts.Features.Students.Queries.Models;

namespace University.Application.Layer.Features.Students.Queries.Handlers
{
    public sealed class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentsQuery, Response<List<GetStudentListResponse>>>
    {
        private readonly IStudentRepositry _studentRepositry;
        private readonly IMapper _mapper;
        public GetAllStudentQueryHandler(IStudentRepositry studentRepositry,IMapper mapper)
        {
            _studentRepositry =studentRepositry;
            _mapper =mapper;
        }
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var studentList = await _studentRepositry.GetStudentsAsync();
                var reseult = _mapper.Map<List<GetStudentListResponse>>(studentList);
                if (reseult != null) return ResponseHandler.Success(reseult);
                return ResponseHandler.Failed<List<GetStudentListResponse>>();
            }
            catch (Exception ex) 
            {
               return ResponseHandler.FaildException<List<GetStudentListResponse>>(ex);
            }
         }
       
    }
}
