using BP.Service.DTOs.DistanceDTOs;
using BP.Service.DTOs.FrequencyDTOs;
using BP.Service.DTOs.WeightDTOs;
using System.Collections.Generic;
using System.Linq;

namespace BP.Service.DTOs.AssessmentDTOs
{
    public class AssessmentDTO
    {
        public List<AssessmentListDTO> Assessments { get; set; }
        public AllDataDTO Options { get; set; }
    }
}
