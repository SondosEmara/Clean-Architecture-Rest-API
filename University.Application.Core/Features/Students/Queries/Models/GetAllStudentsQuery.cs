using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;
using University.Presentaion.Contracts.Bases;
using University.Presentaion.Contracts.Features.Students.Queries.Results;
namespace University.Presentaion.Contracts.Features.Students.Queries.Models
{
    //The api input
    public record GetAllStudentsQuery():IRequest<Response<List<GetStudentListResponse>>>;
}
