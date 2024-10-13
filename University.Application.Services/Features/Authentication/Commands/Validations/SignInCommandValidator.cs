using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Features.Authentication.Commands.Models;

namespace University.Application.Layer.Features.Authentication.Commands.Validations
{
    public class SignInCommandValidator:AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            ApplyValidationsRules();
        }

        private void ApplyValidationsRules()
        {
            RuleFor(user => user.UserName)
                   .NotEmpty().WithMessage("The Username Should Not Empty")
                   .NotNull().WithMessage("The Username Should Exist");  
            
            RuleFor(user=>user.PassWord).NotEmpty().WithMessage("The Username Should Not Empty")
                   .NotNull().WithMessage("The Username Should Exist");

        }
    }
}
