using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Services.Students.DTO;

namespace University.Application.Layer.Services.Students.Behaviour
{
    public class EditStudentValidator : AbstractValidator<EditStudentDto>
    {
        public EditStudentValidator()
        {
            RuleFor(student => student.Id)
                .NotNull().WithMessage("The ID Mandratory");


            RuleFor(student => student.UserName)
                 .NotEmpty().WithMessage("Please UserName Mandratory")
                 .Length(4, 150).WithMessage("Please Enter Your Name With Length 50--150 char");


            RuleFor(student => student.Email)
                   .NotEmpty().WithMessage("Please Email Mandratory")
                   .NotNull().WithMessage("Please the email cant null..")
                   .Matches(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$").WithMessage("Please Email Format..");
        }
    }
}
