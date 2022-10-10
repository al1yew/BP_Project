using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Extensions
{
    public static class IdentityKeeper
    {
        public static void IdentityBuilder(this IServiceCollection services)
        {
            //services.AddIdentity<AppUser, IdentityRole>(options =>
            //{
            //    options.User.RequireUniqueEmail = true;
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireNonAlphanumeric = false;

            //    options.Lockout.AllowedForNewUsers = true;
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.MaxFailedAccessAttempts = 5;

            //}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

        }
    }
}
