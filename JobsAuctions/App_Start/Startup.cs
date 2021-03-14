using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JobsAuctions.Startup))]
namespace JobsAuctions
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}