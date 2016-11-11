using Owin;

namespace OwinHttpListener
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseEcho();
        }
    }
}