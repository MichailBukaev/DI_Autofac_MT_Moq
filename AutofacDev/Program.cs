    using Autofac.Extensions.DependencyInjection;
    using MassTransit;
    using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
using Serilog;

namespace AutofacDev
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
            //Log.Logger = new LoggerConfiguration() <- can do so or str 26
            //    .ReadFrom.Configuration(config)
            //    .CreateLogger();

            return Host.CreateDefaultBuilder(args)
                .UseSerilog((context, c) => c.ReadFrom.Configuration(context.Configuration))//<- can do so or str 21
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())//<- This is for ASP.NET Core 3+
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseConfiguration(config)
                        .UseStartup<Startup>();
                    //.ConfigureServices(c => c.AddAutofac()); <- This is for ASP.NET Core 1.1 - 2.2
                });
        }
            
    }
}
