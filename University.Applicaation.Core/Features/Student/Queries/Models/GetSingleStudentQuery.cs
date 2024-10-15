using MediatR;
using University.Applicaation.Core.Common.Bases;
using University.Application.Layer.Services.Students.Result;

namespace University.Applicaation.Core.Features.Students.Queries.Models
{
    public record GetSingleStudentQuery(int? id) : IRequest<Response<GetSingleStudentResponse>>;
}
