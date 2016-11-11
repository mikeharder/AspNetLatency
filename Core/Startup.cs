using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Core
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(LogLevel.Trace);

            app.UseEcho();

            //app.Run((context) => {
            //    context.Response.StatusCode = 404;
            //    return Task.FromResult(0);
            //});
            // app.Use()
        }
    }
}
