using System.Threading.Tasks;
using Messages;

namespace MailServiceHost.Processors
{
    public interface INotificationProcessor
    {
        Task SendNotificationAsync(NotificationMessage message);
    }
}