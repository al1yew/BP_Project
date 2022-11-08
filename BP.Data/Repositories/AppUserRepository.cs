using BP.Core.Entities;
using BP.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Data.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
