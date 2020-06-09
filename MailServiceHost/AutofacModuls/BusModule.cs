using Autofac;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace MailServiceHost.AutofacModuls
{
    public class BusModule : Module
    {
        private IConfiguration _configuration;

        public BusModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
              builder.Register(context =>
              {
                  return MassTransit.Bus.Factory.CreateUsingRabbitMq(cfg =>
                  {
                      cfg.Host(_configuration["Host"]);

                      cfg.ReceiveEndpoint(_configuration["queueName"], ec =>
                      {
                          ec.ConfigureConsumers(context);
                      });
                  });
              })
                .As<IBusControl>()
                .As<IBus>()
                .SingleInstance();
        }
    }
}
