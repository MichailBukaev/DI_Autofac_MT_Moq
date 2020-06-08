using Autofac;
using MailServiceHost.Processors;
using Microsoft.Extensions.Configuration;

namespace MailServiceHost.AutofacModuls
{
    public class ComponentsModule:Module
    {
        private IConfiguration _configuration;

        public ComponentsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>();
            builder.RegisterType<LetterProcessor>().As<ILetterProcessor>();
        }
    }
}
