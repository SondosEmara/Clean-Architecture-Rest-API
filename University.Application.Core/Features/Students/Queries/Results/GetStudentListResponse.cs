using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;

namespace University.Presentaion.Contracts.Features.Students.Queries.Results
{
    public record GetStudentListResponse 
    {
        public int Id { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? StudLevel { get; init; }
    }
}
