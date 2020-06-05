using Microsoft.Extensions.Configuration;

namespace Contexts
{
    public interface IContext
    {
        IConfiguration Configuration { get; set; }
    }
}