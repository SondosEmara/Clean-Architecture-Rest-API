using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Application.Layer.Features.Email.Commands.Models;
using University.Presentaion.AppMetaData;

namespace University.Presentaion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : AppControllerBase
    {
        public EmailController()
        {
            
        }

        [HttpPost(Router.EmailRoutiing.SendEmail)]
        public async Task<IActionResult> SendEmailAsync([FromQuery]SendEmailCommand _sendEmailCommand)
        {
            var result= await Mediator.Send(_sendEmailCommand);
            return Ok(result);
        }

    }
}
