using MediatR;
using University.Applicaation.Core.Common.Bases;
using University.Application.Layer.Services.Students.Result;

namespace University.Applicaation.Core.Features.Students.Queries.Models
{
    //The api input
    public record GetAllStudentsQuery():IRequest<Response<List<GetStudentListResponse>>>;
}
