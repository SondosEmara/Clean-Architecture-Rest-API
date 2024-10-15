using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Helpers;
using University.Application.Layer.Services.Students.Result;
using University.Application.Layer.Wrappers;

namespace University.Application.Layer.Services.Students.DTO
{

    public record StudentPagniaedListDto
    {
        public int PageSize { get; init; }
        public int PageNumber { get; init; }

        public OrderStudentEnum? OrderBy { get; init; }

        public string? Search { get; init; }

    }
}
