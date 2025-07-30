using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidators : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidators()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Id is required")
                                .EmailAddress().WithMessage("Enter valid Email Id");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Person name is required");
            RuleFor(x => x.Gender).IsInEnum<RegisterRequest,GenderOptions>();
        }
    }
}
