using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Core
{
    public class EchoMiddleware
    {
        private static readonly PathString _path = new PathString("/echo");

        private static readonly byte[] _response = Encoding.UTF8.GetBytes(@"{""foo"":""dafgdsfgsdfg"",""bar"":""fddfsafdsf""}");

        private readonly RequestDelegate _next;

        public EchoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments(_path, StringComparison.Ordinal))
            {
                if (httpContext.Request.Method.Equals("GET", StringComparison.Ordinal))
                {
                    if (httpContext.Request.QueryString.Value.Equals("?async", StringComparison.Ordinal))
                    {
                        httpContext.Response.StatusCode = 201;
                        return httpContext.Response.Body.WriteAsync(_response, 0, _response.Length);
                    }
                    else
                    {
                        httpContext.Response.Body.Write(_response, 0, _response.Length);
                        return Task.CompletedTask;
                    }
                }
                else if (httpContext.Request.Method.Equals("POST", StringComparison.Ordinal))
                {
                    if (httpContext.Request.QueryString.Value.Equals("?async", StringComparison.Ordinal))
                    {
                        httpContext.Response.StatusCode = 201;
                        return httpContext.Request.Body.CopyToAsync(httpContext.Response.Body);
                    }
                    else
                    {
                        httpContext.Request.Body.CopyTo(httpContext.Response.Body);
                        return Task.CompletedTask;
                    }
                }
            }

            return _next(httpContext);
        }
    }

    public static class EchoMiddlewareExtensions
    {
        public static IApplicationBuilder UseEcho(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EchoMiddleware>();
        }
    }
}
