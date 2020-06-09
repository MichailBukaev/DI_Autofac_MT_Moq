using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MassTransit;
using SMSServiceHost.Processors;
using System.Collections.Specialized;
using System.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Data;
using Topshelf.Logging;


namespace SMSServiceHost
{
    public class WindsorInstaller: IWindsorInstaller
    {
       

        internal static IWindsorContainer CreateContainer()
        {
            return new WindsorContainer().Install(new WindsorInstaller());
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Component.For<INameProcessor>().ImplementedBy<NameProcessor>().DependsOn(
                Dependency.OnValue("name", ConfigurationManager.AppSettings["nameSMSProcessor"]))
                .LifestyleSingleton());
            //var logger = CreateLoggerInstance();
            container.Register(Component.For<ISmsProcessor>().ImplementedBy<SmsProcessor>().DependsOn(
                    Dependency.OnValue("provider", ConfigurationManager.AppSettings["provider"]),
                    Dependency.OnValue("logger", HostLogger.Get<SmsProcessor>()))
                .LifestyleTransient());
            InstallBus(container);
        }

        private Serilog.ILogger CreateLoggerInstance()
        {
           return new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();
        }

        private void InstallBus(IWindsorContainer container)
        {
            container.AddMassTransit(x =>
            {
                x.AddConsumers(Assembly.GetExecutingAssembly());
                x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(ConfigurationManager.AppSettings["host"]);
                    cfg.ReceiveEndpoint(ConfigurationManager.AppSettings["queueName"], ep =>
                    {
                        ep.ConfigureConsumers(context);
                    });
                }));
            });
        }
    }
}
