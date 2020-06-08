using System.Threading.Tasks;
using Messages;
using Microsoft.Extensions.Logging;

namespace MailServiceHost.Processors
{
    public class LetterProcessor : ILetterProcessor
    {
        private ILogger<LetterProcessor> _logger;

        public LetterProcessor(ILogger<LetterProcessor> logger)
        {
            _logger = logger;
        }

        public async Task SendMail(SendLetterMessage message)
        {
             _logger.LogInformation("Send Letter to EMail. Text {@message}", message);
        }
    }
}
