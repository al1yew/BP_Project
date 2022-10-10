using BP.Core.Entities;
using BP.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Data.Repositories
{
    public class DistanceRepository : Repository<Distance>, IDistanceRepository
    {
        public DistanceRepository(AppDbContext context) : base(context)
        {

        }
    }
}
