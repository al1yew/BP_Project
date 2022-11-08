using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.AccountDTOs
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be filled!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname must be filled!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email must be filled!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName must be filled!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must be filled!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password must be filled!");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password does not match Confirm Password!");
        }
    }
}
