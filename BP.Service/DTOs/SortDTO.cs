using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs
{
    public class SortDTO
    {
        public int WeightId { get; set; }
        public int FrequencyId { get; set; }
        public int DistanceId { get; set; }
        public int NeedToAssess { get; set; }
        public int ShowCount { get; set; }
        public int Page { get; set; }
    }
}
