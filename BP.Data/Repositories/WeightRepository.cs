using BP.Core.Entities;
using BP.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Data.Repositories
{
    public class WeightRepository : Repository<Weight>, IWeightRepository
    {
        public WeightRepository(AppDbContext context) : base(context)
        {

        }
    }
}
