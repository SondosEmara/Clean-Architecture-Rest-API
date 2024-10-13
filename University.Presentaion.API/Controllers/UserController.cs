using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Application.Layer.Common.Bases;
using University.Application.Layer.Features.Students.Commands.Models;
using University.Application.Layer.Features.User.Commands.Models;
using University.Presentaion.AppMetaData;
namespace University.Presentaion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AppControllerBase
    {
        [HttpPost(Router.UserRouting.RegisterUser)]
        public async Task<IActionResult> RegisterUser([FromQuery]AddUserCommand addUserCommand)
        {
            var result=await Mediator.Send(addUserCommand);
            return Ok(result);

        }

       
    }
}
