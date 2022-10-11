using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.DistanceDTOs
{
    public class DistancePostDTO
    {
        public string Name { get; set; }
    }

    public class DistancePostDTOValidator : AbstractValidator<DistancePostDTO>
    {
        public DistancePostDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Distance cannot be empty!");
        }
    }
}
