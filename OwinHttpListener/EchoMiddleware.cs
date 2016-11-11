using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OwinHttpListener
{
    public class EchoMiddleware
    {
        private static readonly PathString _path = new PathString("/echo");
        private static readonly byte[] _response = Encoding.UTF8.GetBytes(@"{""foo"":""dafgdsfgsdfg"",""bar"":""fddfsafdsf""}");

        private readonly Func<IDictionary<string, object>, Task> _next;

        public EchoMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            IOwinContext context = new OwinContext(environment);

            if (context.Request.Path.StartsWithSegments(_path))
            {
                if (context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
                {
                    context.Response.Body.Write(_response, 0, _response.Length);
                    return Task.CompletedTask;
                }
                else if (context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    context.Request.Body.CopyTo(context.Response.Body);
                    return Task.CompletedTask;
                }
            }

            return _next(context.Environment);
        }
    }

    public static class EchoMiddlewareExtensions
    {
        public static IAppBuilder UseEcho(this IAppBuilder builder)
        {
            return builder.Use<EchoMiddleware>();
        }
    }
}