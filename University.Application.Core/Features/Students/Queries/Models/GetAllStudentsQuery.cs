using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;
namespace University.Presentaion.Contracts.Features.Students.Queries.Models
{
    //The api input
    public record GetAllStudentsQuery():IRequest<List<Student>>;
}
