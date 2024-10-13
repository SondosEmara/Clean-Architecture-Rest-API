using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;
using University.Application.Layer.Common.Interfaces;
using University.Application.Layer.Features.Students.Queries.Models;
using University.Application.Layer.Features.Students.Queries.Results;
using University.Application.Layer.Wrappers;
using University.Domain.Layer.Enities;
using University.Presentaion.Contracts.Features.Students.Queries.Models;

namespace University.Application.Layer.Features.Students.Queries.Handlers
{
    public class GetStudentPagniaedListQueryHandler : IRequestHandler<GetStudentPagniaedListQuery, Response<PagniationResult<GetStudentListResponse>>>
    {
        private readonly IStudentRepositry _studentRepositry;
        public GetStudentPagniaedListQueryHandler(IStudentRepositry studentRepositry)
        {
            _studentRepositry = studentRepositry;            
        }
        public async Task<Response<PagniationResult<GetStudentListResponse>>> Handle(GetStudentPagniaedListQuery request, CancellationToken cancellationToken)
        {
            //Create Func Input is Student and Output is the GetStudentPagniaedListQuery
            Expression<Func<Student, GetStudentListResponse>> expression = (studentInput) =>  new GetStudentListResponse { Id=studentInput.Id, UserName=studentInput.UserName,Email=studentInput.Email,PhoneNumber=studentInput.PhoneNumber,StudLevel=studentInput.Level.ToString()};
            var dataItems = _studentRepositry.GetAllNoTracking();
            var paginationResultl =await dataItems
                                          .Select(expression)
                                          .ToPaginaedListAsync(request.PageSize,request.PageNumber);
            return ResponseHandler.Success(paginationResultl);
        }
    }
}
