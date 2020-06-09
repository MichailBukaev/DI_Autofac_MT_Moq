using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Messages;
using SMSServiceHost.Processors;

namespace SMSServiceHost.Consumers
{
    public class SMSConsumer:IConsumer<SMSMessage>
    {
        private ISmsProcessor _processor;

        public SMSConsumer(ISmsProcessor processor)
        {
            _processor = processor;
        }

        public async Task Consume(ConsumeContext<SMSMessage> context)
        {
            var smsIsNotSend = new SMSIsNotSendMessage();
            var smsIsSend =  _processor.SendSMS(context.Message, ref smsIsNotSend);
            if (smsIsSend != null)
            {
                await context.RespondAsync<SMSIsSendMessage>(smsIsSend);
            }
            else
            {
                await context.RespondAsync<SMSIsNotSendMessage>(smsIsNotSend);
            }
        }
    }
}
