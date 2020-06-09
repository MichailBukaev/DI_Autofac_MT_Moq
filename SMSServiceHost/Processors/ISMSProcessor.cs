using Messages;
using System.Threading.Tasks;

namespace SMSServiceHost.Processors
{
    public interface ISmsProcessor
    {
        public INameProcessor Name { get; set; }
        Task PushNotification(NotificationMessage message);
        SMSIsSendMessage SendSMS(SMSMessage message, ref SMSIsNotSendMessage smsIsNotSend);
    }
}