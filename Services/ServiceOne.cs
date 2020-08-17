using System;
using System.Net.Mime;
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
      _logger.LogInformation("Notification {@text} is push!", text);
      _busControl.Publish<NotificationMessage>(new {Text = text});
    }

    public async void SendEmail(string text)
    {
      Uri senderEMailAdress = new Uri(Context.Configuration["senderEMailUri"]);
      var endpoint = await _busControl.GetSendEndpoint(senderEMailAdress);
      await endpoint.Send<SendLetterMessage>(new {Message = text});
      _logger.LogInformation("Letter {@text} is send to EMail!", text);
    }

    public async Task<string> SendSms(string text)
    {
      Uri senderSMSAdress = new Uri(Context.Configuration["senderSMSUri"]);
      var client = _busControl.CreateRequestClient<SMSMessage>(senderSMSAdress);

      var (smsIsSendResponse, smsIsNotSendResponse) =
        await client.GetResponse<SMSIsSendMessage, SMSIsNotSendMessage>(new {Text = text});
      if (smsIsSendResponse.IsCompletedSuccessfully)
      {
        var respons = await smsIsSendResponse;
        _logger.LogInformation("SMS: {@text} is send in {@dataTime}!", respons.Message.Text, respons.Message.DateTime);
        return $"SMS: |{respons.Message.Text}| is send in {respons.Message.DateTime}!";
      }
      else
      {
        var respons = await smsIsNotSendResponse;
        _logger.LogError("SMS: {@text} is not send with problem {@problem}!", respons.Message.Text,
          respons.Message.Problem);
        return $"SMS: {respons.Message.Text} is not send with problem {respons.Message.Problem}!";
      }
    }
  }
}