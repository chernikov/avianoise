using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace avianoise.Web.Middlewares
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<RequestLogMiddleware> logger)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                var startTime = DateTime.Now.Ticks;
                await _next.Invoke(context);

                var total = (DateTime.Now.Ticks - startTime) / 10000;
                var isError = (context.Response.StatusCode / 100) > 3;

                var authService = context.RequestServices.GetRequiredService<IAuthorizationService>();
                var userInfo = string.Empty;
                if (context.User.Identity.IsAuthenticated)
                {
                    var identity = context.User.Identity;
                    if (identity is ClaimsIdentity)
                    {
                        var claimsList = ((ClaimsIdentity)identity).Claims.ToList();
                        var sid = claimsList.FirstOrDefault(p => p.Type == ClaimTypes.Sid).Value;
                        if (!string.IsNullOrEmpty(sid))
                        {
                            var id = Int32.Parse(sid);
                            var user = claimsList.FirstOrDefault(p => p.Type == "user")?.Value;
                            if (user != null)
                            {
                                userInfo = JsonConvert.SerializeObject(user);
                            }
                        }
                    }
                }
                var path = $"{context.Request.Path.Value.ToLower()}{context.Request.QueryString}";
                logger.LogInformation($"{(isError ? "[ERROR]" : "[REQUEST]")}\t{context.Response.StatusCode}\t{total} ms\t{context.Request.Method}: {path}\tUser : {userInfo}");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
