using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Id is required")
                                 .EmailAddress().WithMessage("Enter valid Email Id");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
