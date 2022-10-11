using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Core.Entities
{
    public class WeightToDistanceToFrequency
    {
        public int Id { get; set; }
        public Weight Weight { get; set; }
        public int WeightId { get; set; }
        public Distance Distance { get; set; }
        public int DistanceId { get; set; }
        public Frequency Frequency { get; set; }
        public int FrequencyId { get; set; }
        public bool NeedToAssess { get; set; }
    }
}
