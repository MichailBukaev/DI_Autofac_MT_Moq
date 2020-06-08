using System;
using System.Threading.Tasks;
using Contexts;
using Data;
using MassTransit;
using Messages;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class ServiceOne : IServiceOne
    {
        private readonly IDataAccess _dataAccess;
        private readonly ILogger<ServiceOne> _logger;
        private readonly IBusControl _busControl;
        public IContext Context { get; set; }

        public ServiceOne(IDataAccess dataAccess, ILogger<ServiceOne> logger, IBusControl busControl)
        {
            _dataAccess = dataAccess;
            _logger = logger;
            _busControl = busControl;
        }

        public string Loading()
        {
            var result = _dataAccess.LoadData(Context.Configuration["serviceOne"]);
            _logger.LogInformation(result);
            return result;
        }

        public string Saving(string name)
        {
            var result = _dataAccess.SaveData(name);
            _logger.LogInformation(result);
            return result;
        }

        public void SetDataName(string dataName)
        {
            _dataAccess.SetDataName(dataName);
            _logger.LogInformation("Set Name of data: {@dataName}. Data Access {@dataAccess}", dataName, _dataAccess);
        }

        public void PushNotification(string text)
        {
            _busControl.Publish<NotificationMessage>(new {Text = text});
        }

        public async void SendEmail(string text)
        {
            Uri senderEMailAdress = new Uri(Context.Configuration["senderEMailUri"]);
            var endpoint = await _busControl.GetSendEndpoint(senderEMailAdress);
            await endpoint.Send<SendLetterMessage>(new { Message = text});

        }
    }
}
