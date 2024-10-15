using MediatR;
using University.Application.Layer.Services.Students.DTO;
using University.Applicaation.Core.Common.Bases;
namespace University.Application.Layer.Features.Students.Commands.Models
{
    public record EditStudentCommand : IRequest<Response<string>>
    {
        public EditStudentDto EditStudentDto { get; set; } = null!;
      
    }
}
