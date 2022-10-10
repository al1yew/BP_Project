using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.WeightDTOs
{
    public class WeightPostDTO
    {
        public string Name { get; set; }
    }

    public class WeightPostDTOValidator : AbstractValidator<WeightPostDTO>
    {
        public WeightPostDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Weight cannot be empty!");
        }
    }
}
