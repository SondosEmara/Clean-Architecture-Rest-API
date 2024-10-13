using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;
using University.Application.Layer.Features.Students.Queries.Results;
using University.Application.Layer.Helpers;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Features.Students.Queries.Models
{
    public record GetStudentFilteredQuery:IRequest<Response<IQueryable<Student>>>
    {
        public string? SerachTerm { get; set; }
        public OrderStudentEnum? OrderBy { get; set; }
    }
}
