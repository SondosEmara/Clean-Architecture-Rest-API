using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;
using University.Application.Layer.Features.Students.Queries.Results;

namespace University.Application.Layer.Features.Students.Queries.Models
{
    public record GetSingleStudentQuery(int? id) : IRequest<Response<GetSingleStudentResponse>>;
}
