using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MailServiceHost
{
    public class Worker: BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IBusControl _bus;

        public Worker(ILogger<Worker> logger, IBusControl bus)
        {
            _logger = logger;
            _bus = bus;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _bus.Start();
            _logger.LogInformation("Bus start!");
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _bus.Stop();
            _logger.LogInformation("Bus stop!");
            return base.StopAsync(cancellationToken);
        }
    }
}
