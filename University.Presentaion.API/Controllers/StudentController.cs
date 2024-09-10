using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Presentaion.Contracts.Features.Students.Queries.Models;

namespace University.Presentaion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)=>_mediator=mediator;

        //Add Auth-Service........!
        //Make Role=Admin........!
        [HttpGet("Get-All-Students")]
        public async Task<IActionResult> GetStudentList()
        {
           var response=await _mediator.Send(new GetAllStudentsQuery());
           return Ok(response);
        }
    }
}
