using System.Reflection;
using Autofac;
using Contexts;
using Data;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Services;
using Module = Autofac.Module;

namespace AutofacDev
{
    internal class AutofacModule : Module
    {
        private IConfiguration _configuration;

        public AutofacModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().As<IContext>()
                .WithProperty("Configuration", _configuration);
            builder.RegisterType<ServiceOne>().As<IServiceOne>().PropertiesAutowired();
            builder.RegisterType<ServiceTwo>().As<IServiceTwo>()
                .WithParameter("name", _configuration["ServiceTwoName"])
                .PropertiesAutowired();
            builder.RegisterType<DataAccess>().As<IDataAccess>().PropertiesAutowired();
            builder.RegisterType<Name>().As<IName>().InstancePerLifetimeScope();
            LoadBus(builder);
        }

        private  void LoadBus(ContainerBuilder builder)
        {
            
            builder.AddMassTransit(x =>
            {
                x.AddConsumers(Assembly.GetExecutingAssembly());
                x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(_configuration["Host"]);
                    cfg.ReceiveEndpoint(_configuration["queueName"], ep =>
                    {
                        ep.AutoDelete = true;
                        ep.ConfigureConsumers(context);
                    });
                }));
            });
        }

        
    }
}