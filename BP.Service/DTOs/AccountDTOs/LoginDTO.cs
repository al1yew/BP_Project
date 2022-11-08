using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.AccountDTOs
{
    public class LoginDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Enter Password!")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters!");

            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Enter Login!");
        }
    }
}
