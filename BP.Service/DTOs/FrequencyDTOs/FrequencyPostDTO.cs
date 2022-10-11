using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.FrequencyDTOs
{
    public class FrequencyPostDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FrequencyPostDTOValidator : AbstractValidator<FrequencyPostDTO>
    {
        public FrequencyPostDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Frequency cannot be empty!");
        }
    }
}
