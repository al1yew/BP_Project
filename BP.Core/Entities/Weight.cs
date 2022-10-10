﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Core.Entities
{
    public class Weight : BaseEntity
    {
        public string Name { get; set; }

        //relations
        public List<WeightToDistanceToFrequency> WeightToDistanceToFrequencies { get; set; }
    }
}
