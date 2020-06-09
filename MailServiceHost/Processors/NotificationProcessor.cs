using System.Threading.Tasks;
using Messages;
using Microsoft.Extensions.Logging;

namespace MailServiceHost.Processors
{
    public class NotificationProcessor : INotificationProcessor
    {
        private ILogger<NotificationProcessor> _logger;

        public NotificationProcessor(ILogger<NotificationProcessor> logger)
        {
            _logger = logger;
        }

        public async Task SendNotificationAsync(NotificationMessage message)
        {
            _logger.LogInformation("Send notification to EMail. Text {@message}", message);
        }
    }
}
