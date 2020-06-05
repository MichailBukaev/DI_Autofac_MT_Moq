using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace AutofacDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTwoController : ControllerBase
    {
        private readonly IServiceTwo _serviceTwo;
        public ServiceTwoController(IServiceTwo serviceTwo)
        {
            _serviceTwo = serviceTwo;
        }

        [HttpGet]
        public string Get()
        {
            return _serviceTwo.LoadingData();
        }

        [HttpPost]
        [Route("saveData")]
        public string SaveData()
        {
            return _serviceTwo.SavingData();
        }
    }
}
