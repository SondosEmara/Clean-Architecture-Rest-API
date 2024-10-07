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
using University.Application.Layer.Services.Classes;
using University.Application.Layer.Services.Interfaces;

namespace University.Application.Layer.Features.Students.Queries.Handlers
{
    public class GetSingleStudentQueryHandler : IRequestHandler<GetSingleStudentQuery, Response<GetSingleStudentResponse>>
    {
        private readonly IStudentRepositry _studentRepositry;
        private readonly IMapper _mapper;
        public GetSingleStudentQueryHandler(IStudentRepositry studentRepositry, IMapper mapper)
        {
            _studentRepositry = studentRepositry;
            _mapper = mapper;
        }
        public async Task<Response<GetSingleStudentResponse>> Handle(GetSingleStudentQuery request, CancellationToken cancellationToken)
        {
            if (request.id == null) return ResponseHandler.Failed<GetSingleStudentResponse>();
            try
            {
                var targetStudent = await _studentRepositry.GetByIdAsync(request.id.Value);
                var reseult = _mapper.Map<GetSingleStudentResponse>(targetStudent);
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
