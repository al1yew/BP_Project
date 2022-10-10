using BP.Core.Entities;
using BP.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Data.Repositories
{
    public class FrequencyRepository : Repository<Frequency>, IFrequencyRepository
    {
        public FrequencyRepository(AppDbContext context) : base(context)
        {

        }
    }
}
