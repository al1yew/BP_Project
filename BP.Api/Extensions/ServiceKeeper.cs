using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Extensions
{
    public static class ServiceKeeper
    {
        public static void ServicesBuilder(this IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
