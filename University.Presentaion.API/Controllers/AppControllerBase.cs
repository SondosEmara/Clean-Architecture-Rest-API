using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace University.Presentaion.API.Controllers
{
    public class AppControllerBase:ControllerBase
    {
        private IMediator? mediator;
        protected IMediator Mediator  => mediator ?? HttpContext.RequestServices.GetService<IMediator>();
    }
}
