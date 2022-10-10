using BP.Service.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Extensions
{
    public static class ExceptionHandler
    {
        public static void ExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();

                    int statuscode = 500;
                    string errormsg = "Internal Server Error!";

                    if (feature.Error is NotFoundException)
                    {
                        statuscode = 404;
                        errormsg = feature.Error.Message;
                    }
                    else if (feature.Error is RecordDublicateException)
                    {
                        statuscode = 409;
                        errormsg = feature.Error.Message;
                    }
                    else if (feature.Error is BadRequestException)
                    {
                        statuscode = 400;
                        errormsg = feature.Error.Message;
                    }

                    context.Response.StatusCode = statuscode;
                    await context.Response.WriteAsync(errormsg);
                });
            });
        }
    }
}
