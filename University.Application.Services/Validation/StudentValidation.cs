using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Validation
{
    public class StudentValidation: AbstractValidator<Student>
    {
        public StudentValidation()
        {
            RuleFor(student => student.UserName).Length(50, 150).WithMessage("Please Enter Your Name With Length 50--150 char")
                                                .NotEmpty().WithMessage("Please UserName Mandratory");
            RuleFor(student => student.Email).NotEmpty();

            //in case the phonenumber entered check that
            When(student => !string.IsNullOrEmpty(student.PhoneNumber), () =>
            {
                RuleFor(student => student.PhoneNumber)
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("If provided, phone number must be in a valid international format.");
            });
        }
    }
}
