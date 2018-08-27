using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Configuration.Install;
using System.IO;
using System.Net.Http;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace NuGetServer.Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var portStr = ConfigurationManager.AppSettings.Get("port");

            if (!int.TryParse(portStr, out var port))
            {
                port = 9028;
            }

            var host = $"http://localhost:{port}/";

            if (args.Length == 1 && args[0] == "/debug")
            {
                using(var app = WebApp.Start<Startup>(host))
                {
                    Console.WriteLine($"Running at {host}");
                    Console.Write("Press any key to stop . . .");
                    Console.Read();
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new WindowService(host)
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }

    #region Service

    public class WindowService : ServiceBase
    {
        private readonly string _hostAddress;
        private IDisposable _app;

        public WindowService(string hostAddress)
        {
            ServiceName = "LocalNuGetService";
            CanPauseAndContinue = false;
            _hostAddress = hostAddress;
        }

        protected override void OnStart(string[] args)
        {
            _app = WebApp.Start<Startup>(url: _hostAddress);
        }

        protected override void OnShutdown()
        {
            _app.Dispose();
        }

        protected override void OnStop()
        {
            _app.Dispose();
        }
    }

    #endregion

    #region Installer

    [RunInstaller(true)]
    public class WindowServiceInstaller : Installer
    {
        private readonly ServiceProcessInstaller _serviceProcessInstaller;
        private readonly ServiceInstaller _serviceInstaller;

        public WindowServiceInstaller()
        {
            _serviceProcessInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalService,
                Username = null,
                Password = null
            };

            _serviceInstaller = new ServiceInstaller
            {
                ServiceName = "LocalNuGetService",
                DisplayName = "Local NuGet Service",
                Description = "A NuGet Server run on local machine",
                StartType = ServiceStartMode.Automatic
            };

            Installers.Add(_serviceProcessInstaller);
            Installers.Add(_serviceInstaller);
        }
    }

    #endregion
}
