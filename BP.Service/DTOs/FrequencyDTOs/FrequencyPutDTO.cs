using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.FrequencyDTOs
{
    public class FrequencyPutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FrequencyPutDTOValidator : AbstractValidator<FrequencyPutDTO>
    {
        public FrequencyPutDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Frequency cannot be empty!");
        }
    }
}
