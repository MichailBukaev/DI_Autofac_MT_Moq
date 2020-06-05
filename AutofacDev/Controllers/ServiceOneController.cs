﻿using Microsoft.AspNetCore.Http.Features;
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
        private readonly IServiceTwo _serviceTwo;
        private readonly ILogger<ServiceOne> _logger;
        public ServiceOneController(IServiceOne serviceOne, ILogger<ServiceOne> logger, IServiceTwo serviceTwo)
        {
            _serviceOne = serviceOne;
            _logger = logger;
            _serviceTwo = serviceTwo;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("This is Controller of Service One");
            return _serviceOne.Loading();
        }

        [HttpPost]
        [Route("SetDataName")]
        public string SetDataName(string dataName)
        {
            _serviceOne.SetDataName(dataName);
            return _serviceOne.Loading()+" ||||| "+_serviceTwo.LoadingData();
        }
        
    }
}