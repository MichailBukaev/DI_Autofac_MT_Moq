
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Messages;
using SMSServiceHost.Processors;

namespace SMSServiceHost.Consumers
{
    public class NotificationConsumer:IConsumer<NotificationMessage>
    {
        private ISmsProcessor _processor;

        public NotificationConsumer(ISmsProcessor processor)
        {
            _processor = processor;
        }

        public async Task Consume(ConsumeContext<NotificationMessage> context)
        {
            await _processor.PushNotification(context.Message);
        }
    }
}
