using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using EventScheduler.Common.Exceptions;

namespace EventScheduler.Problems
{
    public static class BuildInExceptionHandler
    {
        public static void AddErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        if (contextFeature.Error is IEventSchedulerException exception)
                        {
                            if (exception.HttpStatusCode.HasValue)
                            {
                                context.Response.StatusCode = (int)exception.HttpStatusCode.Value;
                            }
                            await context.Response.WriteAsync(exception.ToJson());
                        }
                        else
                        {
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Something went wrong"
                            }));
                        }

                    }
                });
            });
        }
    }
}
