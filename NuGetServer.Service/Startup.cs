using NuGetServer.Service.Extensions;
using Owin;

namespace NuGetServer.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNuGetServerWebApi();
        }
    }
}
