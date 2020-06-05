using Contexts;
using Data;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class ServiceTwo : IServiceTwo
    {
        private readonly IDataAccess _dataAccess;
        private readonly string _name;
        private readonly ILogger<ServiceTwo> _logger;
        public IContext Context { get; set; }

        public ServiceTwo(IDataAccess dataAccess, string name, ILogger<ServiceTwo> logger)
        {
            _dataAccess = dataAccess;
            _name = name;
            _logger = logger;
        }

        public string LoadingData()
        {
            var result = _dataAccess.LoadData(Context.Configuration["serviceTwo"]);
            _logger.LogInformation(result);
            return result;
        }

        public string SavingData()
        {
            var result = _dataAccess.SaveData(_name);
            _logger.LogInformation(result);
            return result;
        }
    }
}
