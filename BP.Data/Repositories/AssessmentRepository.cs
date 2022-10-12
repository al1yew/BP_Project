using BP.Core.Entities;
using BP.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Data.Repositories
{
    public class AssessmentRepository : Repository<Assessment>, IAssessmentRepository
    {
        public AssessmentRepository(AppDbContext context) : base(context)
        {

        }
    }
}
