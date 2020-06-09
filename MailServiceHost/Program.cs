using Autofac;
using Autofac.Extensions.DependencyInjection;
using MailServiceHost.AutofacModuls;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MailServiceHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog((context, c)=>c.ReadFrom.Configuration(context.Configuration))
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new ComponentsModule(config));
                    builder.RegisterModule(new ConsumerModule());
                    builder.RegisterModule(new BusModule(config));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
        }
            
    }
}
