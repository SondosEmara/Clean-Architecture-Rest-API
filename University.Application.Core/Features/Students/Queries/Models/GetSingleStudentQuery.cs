using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Presentaion.Contracts.Bases;
using University.Presentaion.Contracts.Features.Students.Queries.Results;

namespace University.Presentaion.Contracts.Features.Students.Queries.Models
{
    public record GetSingleStudentQuery(int? id) : IRequest<Response<GetSingleStudentResponse>>;
}
