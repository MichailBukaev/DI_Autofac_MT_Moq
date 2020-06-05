using Contexts;
using Data;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class ServiceOne : IServiceOne
    {
        private readonly IDataAccess _dataAccess;
        private readonly ILogger<ServiceOne> _logger;
        public IContext Context { get; set; }

        public ServiceOne(IDataAccess dataAccess, ILogger<ServiceOne> logger)
        {
            _dataAccess = dataAccess;
            _logger = logger;
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
            _logger.LogInformation("Set Name of data: {@dataName}", dataName);
            _dataAccess.SetDataName(dataName);
        }
    }
}
