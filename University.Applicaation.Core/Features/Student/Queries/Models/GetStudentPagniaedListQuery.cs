using MediatR;
using University.Applicaation.Core.Common.Bases;
using University.Application.Layer.Helpers;
using University.Application.Layer.Services.Students.DTO;
using University.Application.Layer.Services.Students.Result;
using University.Application.Layer.Wrappers;

namespace University.ApplicationLayer.Core.Features.Students.Queries.Models
{
    public record GetStudentPagniaedListQuery:IRequest<Response<PagniationResult<GetStudentListResponse>>>
    {
        public StudentPagniaedListDto StudentPagniaedListDto { get; set; } = null!;

    }
}
