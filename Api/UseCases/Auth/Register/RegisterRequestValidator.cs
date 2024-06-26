﻿using FluentValidation;

namespace Api.UseCases.Auth.Register
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
}
