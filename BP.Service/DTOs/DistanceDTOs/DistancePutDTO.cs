using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.DistanceDTOs
{
    public class DistancePutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DistancePutDTOValidator : AbstractValidator<DistancePutDTO>
    {
        public DistancePutDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Distance cannot be empty!");
        }
    }
}
