using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BP.Service.DTOs.AssessmentDTOs
{
    public class AssessmentObjectDTO
    {
        public IQueryable<AssessmentListDTO> Query { get; set; }
        public int TotalCount { get; set; }
    }
}
