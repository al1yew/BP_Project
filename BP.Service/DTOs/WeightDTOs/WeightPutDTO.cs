using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.WeightDTOs
{
    public class WeightPutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class WeightPutDTOValidator : AbstractValidator<WeightPutDTO>
    {
        public WeightPutDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Weight cannot be empty!");
        }
    }
}
