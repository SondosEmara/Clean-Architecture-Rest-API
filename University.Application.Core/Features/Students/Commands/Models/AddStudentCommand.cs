using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enums;
using University.Presentaion.Contracts.Bases;

namespace University.Presentaion.Contracts.Features.Students.Commands.Models
{
    //That DTO The enter in the Api Input,In the futute add the IAuthoriztionRequest.......
    public record AddStudentCommand(String UserName, String Email,String PhoneNumber, StudentLevel Level): IRequest<Response<bool>>;
    
}
