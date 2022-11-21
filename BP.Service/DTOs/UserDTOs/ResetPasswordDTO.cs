using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.UserDTOs
{
    public class ResetPasswordDTO
    {
        public string Id { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
    public class ResetPasswordDToValidator : AbstractValidator<ResetPasswordDTO>
    {
        public ResetPasswordDToValidator()
        {
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("New Password must be filled!");
            RuleFor(x => x.ConfirmNewPassword).NotEmpty().WithMessage("Confirm Password must be filled!");
            RuleFor(x => x.NewPassword).Equal(x => x.ConfirmNewPassword).WithMessage("Password does not match Confirm Password!");
        }
    }
}
