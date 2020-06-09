using System;
using System.Threading.Tasks;
using Messages;
using Topshelf.Logging;

namespace SMSServiceHost.Processors
{
    public class SmsProcessor : ISmsProcessor
    {
        private readonly string _provider;
        private readonly LogWriter _logger;
        public INameProcessor Name { get; set; }
        public SmsProcessor(string provider, LogWriter logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public async Task PushNotification(NotificationMessage message)
        {
            _logger.LogFormat(LoggingLevel.Info, "Notification: {@0} - is push. Processor: {@1}. Provider: {@2}", message.Text, Name.GetName(), _provider);
        }

        public SMSIsSendMessage SendSMS(SMSMessage message, ref SMSIsNotSendMessage smsIsNotSend)
        {
            var random = new Random();
            int exep = random.Next(0, 10);
            if (exep == 6 || exep == 3)
            {
                //_logger.ForContext<SmsProcessor>().Error("Message :{@text} - not send", message.Text);
                _logger.LogFormat(LoggingLevel.Error, "Message :{@text} - not send", message.Text);
                smsIsNotSend = new SMSIsNotSendMessage()
                {
                    Text = message.Text,
                    Problem = exep.ToString()
                };
                return null;
            }
            //_logger.ForContext<SmsProcessor>().Information("Message :{@text} - is send.Processor: {@NameProcessor}. Provider: {@provider}", message.Text, Name.GetName(), _provider);
            _logger.LogFormat(LoggingLevel.Info, "Message :{@text} - is send.Processor: {@NameProcessor}. Provider: {@provider}", message.Text, Name.GetName(), _provider);
            var smsIsSend = new SMSIsSendMessage()
            {
                Text = message.Text,
                DateTime = DateTime.Now
            };

            return new SMSIsSendMessage{Text = smsIsSend.Text, DateTime = smsIsSend.DateTime};
        }
    }
}
