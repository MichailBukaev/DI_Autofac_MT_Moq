using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;

namespace AutofacDev.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ServiceOneController : ControllerBase
  {
    private readonly IServiceOne _serviceOne;
    private readonly ILogger<ServiceOne> _logger;

    public ServiceOneController(IServiceOne serviceOne, ILogger<ServiceOne> logger)
    {
      _serviceOne = serviceOne;
      _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
      var _i = 1;
      var _b = 3;
      _logger.LogInformation("This is Controller of Service One {@_i}, {1}", _i, _b);
      _logger.LogInformation("This is Controller of Service One {@dfsfd}, {b}", _i, _b);
      _logger.LogInformation(@"This is Controller of Service One");
      return _serviceOne.Loading();
    }

    [HttpPost]
    [Route("SetDataName")]
    public string SetDataName(string dataName)
    {
      _serviceOne.SetDataName(dataName);
      return _serviceOne.Loading();
    }

    [HttpPost]
    [Route("PushNotification")]
    public IActionResult PushNotification(string notif)
    {
      _serviceOne.PushNotification(notif);
      return Ok();
    }

    [HttpPost]
    [Route("SendLetter")]
    public IActionResult SendLetter(string letter)
    {
      _serviceOne.SendEmail(letter);
      return Ok();
    }

    [HttpPost]
    [Route("SendSms")]
    public async Task<string> SendSms(string sms)
    {
      string response = await _serviceOne.SendSms(sms);
      return response;
    }
  }
}