using System.Reflection;
using Autofac;
using MailServiceHost.Consumers;
using MassTransit;
using Module = Autofac.Module;

namespace MailServiceHost.AutofacModuls
{
    public class ConsumerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.AddMassTransit(x =>
            {
                //x.AddConsumer<NotificationConsumer>();
                //x.AddConsumer<SendLetterConsumer>();
                x.AddConsumers(Assembly.GetExecutingAssembly());
            });

        }
    }
}
