using Microsoft.Extensions.Configuration;

namespace Contexts
{
    public class Context : IContext
    {
        public IConfiguration Configuration { get; set; }
    }
}
