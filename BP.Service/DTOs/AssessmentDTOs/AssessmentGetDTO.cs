using BP.Service.DTOs.DistanceDTOs;
using BP.Service.DTOs.FrequencyDTOs;
using BP.Service.DTOs.WeightDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.AssessmentDTOs
{
    public class AssessmentGetDTO
    {
        public int Id { get; set; }
        //public WeightGetDTO Weight { get; set; }
        public int WeightId { get; set; }
        //public FrequencyGetDTO Frequency { get; set; } 
        public int FrequencyId { get; set; }
        //public DistanceGetDTO Distance { get; set; }
        public int DistanceId { get; set; }
        public bool NeedToAssess { get; set; }

    }
}
