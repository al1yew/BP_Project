using BP.Service.DTOs.DistanceDTOs;
using BP.Service.DTOs.FrequencyDTOs;
using BP.Service.DTOs.WeightDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs
{
    public class AllDataDTO
    {
        public List<WeightListDTO> Weights { get; set; }
        public List<DistanceListDTO> Distances { get; set; }
        public List<FrequencyListDTO> Frequencies { get; set; }
    }
}
