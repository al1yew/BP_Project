using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Extensions
{
    public static class EndpointKeeper
    {
        public static void EndpointBuilder(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("Default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
