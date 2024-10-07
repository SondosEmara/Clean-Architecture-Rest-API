using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Features.Students.Commands.Models;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Features.Students.Commands.Behaviour
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        public AddStudentCommandValidator()
        {
            RuleFor(student => student.UserName)
                  .NotEmpty().WithMessage("Please UserName Mandratory")
                  .Length(4, 150).WithMessage("Please Enter Your Name With Length 50--150 char");


            RuleFor(student => student.Email)
                   .NotEmpty().WithMessage("Please Email Mandratory")
                   .NotNull().WithMessage("Please the email cant null..")
                   .Matches(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$").WithMessage("Please Email Format..");


            //in case the phonenumber entered check that
            When(student => !string.IsNullOrEmpty((student.PhoneNumber).ToString()), () =>
            {
                RuleFor(student => student.PhoneNumber.ToString())
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("If provided, phone number must be in a valid international format.");
            });
        }
    }
}
