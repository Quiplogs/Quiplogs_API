using Api.Models.Requests;
using FluentValidation;
using System.Linq;

namespace Api.Models.Validation
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
            RuleFor(x => x.UserName).Length(5, 255);
            RuleFor(x => x.Password).Length(6, 15);
        }
    }

    public class RegisterCompanyRequestValidator : AbstractValidator<RegisterCompanyRequest>
    {
        public RegisterCompanyRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Company Name is required");
            RuleFor(x => x.UserName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
            RuleFor(x => x.Password).Length(6, 255);
            RuleFor(x => x.Address1)
                .NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Coumtry is required");
            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email address is required")
                    .EmailAddress().WithMessage("A valid email is required");
        }
    }
}
