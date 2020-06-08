using System;
using System.Threading.Tasks;
using MailServiceHost.Processors;
using MassTransit;
using Messages;

namespace MailServiceHost.Consumers
{
    public class SendLetterConsumer:IConsumer<SendLetterMessage>
    {
        private readonly ILetterProcessor _processor;

        public SendLetterConsumer(ILetterProcessor processor)
        {
            _processor = processor;
        }

        public Task Consume(ConsumeContext<SendLetterMessage> context)
        {
            return _processor.SendMail(context.Message);
        }
    }
}
