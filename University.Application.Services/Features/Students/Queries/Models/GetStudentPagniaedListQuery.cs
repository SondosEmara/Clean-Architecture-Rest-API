﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;
using University.Application.Layer.Features.Students.Queries.Results;
using University.Application.Layer.Helpers;
using University.Application.Layer.Wrappers;

namespace University.Application.Layer.Features.Students.Queries.Models
{
    public record GetStudentPagniaedListQuery:IRequest<Response<PagniationResult<GetStudentListResponse>>>
    {
        public int PageSize {  get; init; }
        public int PageNumber {  get; init; }

        public OrderStudentEnum? OrderBy { get; init; }

        public string? Search { get; init; }

    }
}
