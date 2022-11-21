using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.AssessmentDTOs
{
    public class MakeAssessmentDTO
    {
        public int WeightId { get; set; }
        public int FrequencyId { get; set; }
        public int DistanceId { get; set; }
    }

    public class MakeAssessmentDTOValidator : AbstractValidator<MakeAssessmentDTO>
    {
        public MakeAssessmentDTOValidator()
        {
            RuleFor(x => x.DistanceId).NotEmpty().WithMessage("Select distance!");
            RuleFor(x => x.FrequencyId).NotEmpty().WithMessage("Select frequency!");
            RuleFor(x => x.WeightId).NotEmpty().WithMessage("Select weight!");
        }
    }
}
