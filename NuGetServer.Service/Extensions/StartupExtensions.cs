using System.Diagnostics;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using NuGet.Server;
using NuGet.Server.Infrastructure;
using NuGet.Server.V2;
using Owin;

namespace NuGetServer.Service.Extensions
{
    public static class StartupExtensions
    {
        public static IAppBuilder UseNuGetServerWebApi(this IAppBuilder app)
        {
            ServiceResolver.SetServiceResolver(new DefaultServiceResolver());

            var config = new HttpConfiguration();

            NuGetV2WebApiEnabler.UseNuGetV2WebApiFeed(config, "NuGetDefault", "nuget", "PackagesOData");

            config.Services.Replace(typeof(IExceptionLogger), new TraceExceptionLogger());

            Trace.Listeners.Add(new TextWriterTraceListener(HostingEnvironment.MapPath("~/NuGet.Server.log")));
            Trace.AutoFlush = true;

            config.Routes.MapHttpRoute(
                name: "NuGetDefault_ClearCache",
                routeTemplate: "nuget/clear-cache",
                defaults: new { controller = "PackagesOData", action = "ClearCache" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            app.UseWebApi(config);

            return app;
        }
    }
}
