using Autofac;
using Contexts;
using Data;
using Microsoft.Extensions.Configuration;
using Services;

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
            builder.RegisterType<DataAccess>().As<IDataAccess>();
            builder.RegisterType<Name>().As<IName>().SingleInstance();
        }

        
    }
}