using System;
using Serilog;
using Topshelf;

namespace SMSServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerConfiguration = new LoggerConfiguration().ReadFrom.AppSettings();
            HostFactory.Run(x =>
            {
                x.Service<SvcHost>(s =>
                {
                    s.ConstructUsing(settings => new SvcHost());

                    s.WhenStarted(svc => svc.Start());
                    s.WhenStopped(svc => svc.Stop());
                    s.WhenShutdown(svc => svc.Stop());
                });
                x.UseSerilog(loggerConfiguration);
                x.RunAsLocalService();
                x.SetDescription("SMS Service Host");
                x.SetDisplayName("SMSServiceHost");
                x.SetServiceName("SMSServiceHost");
            });
        }
    }

}
