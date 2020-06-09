using System.Threading.Tasks;
using MailServiceHost.Processors;
using MassTransit;
using Messages;

namespace MailServiceHost.Consumers
{
    public class NotificationConsumer: IConsumer<NotificationMessage>
    {
        private readonly INotificationProcessor _processor;

        public NotificationConsumer(INotificationProcessor processor)
        {
            _processor = processor;
        }

        public Task Consume(ConsumeContext<NotificationMessage> context)
        { 
            return _processor.SendNotificationAsync(context.Message);
        }
    }
}
