using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Presentaion.Contracts.Features.Students.Queries.Models;
using University.Presentaion.AppMetaData;
using University.Application.Layer.Features.Students.Queries.Models;
using University.Application.Layer.Features.Students.Commands.Models;
using University.Application.Layer.Features.Students.Queries.Handlers;
using University.Application.Layer.Features.User.Commands.Models;

namespace University.Presentaion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : AppControllerBase
    {
        public StudentController() { }
        ////////private readonly IMediator _mediator;
        ////////public StudentController(IMediator mediator)=>_mediator=mediator;
        //Add Auth-Service........!
        //Make Role=Admin........!
        [HttpGet(Router.StudentRouting.GetStudentsList)]
        public async Task<IActionResult> GetStudentList()
        {
           var response=await Mediator.Send(new GetAllStudentsQuery());
           return Ok(response);
        }


        [HttpGet(Router.StudentRouting.GetStudentPaginaedList)]
        public async Task<IActionResult> GetStudentPaginaedList([FromQuery] GetStudentPagniaedListQuery? _paginadQuery)
        {
            var response = await Mediator.Send(_paginadQuery);
            return Ok(response);
        }


        [HttpGet(Router.StudentRouting.GetStudentById)]
        public async Task<IActionResult> GetStudent(int? id)
        {
            var response = await Mediator.Send(new GetSingleStudentQuery(id));
            return Ok(response);
        }



        [HttpPost(Router.StudentRouting.CreateStudent)]
        public async Task<IActionResult>CreateStudent([FromBody] AddStudentCommand newStudent)
        {
            var response = await Mediator.Send(newStudent);
            return Ok(response);    
        }


        [HttpPost(Router.StudentRouting.UpdateStudent)]
        public async Task<IActionResult> CreateStudent([FromBody] EditStudentCommand updateStudent)
        {
            var response = await Mediator.Send(updateStudent);
            return Ok(response);
        }
    }
}
