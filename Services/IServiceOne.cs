using Contexts;

namespace Services
{
    public interface IServiceOne
    {
        string Loading();
        string Saving(string name);
        void SetDataName(string dataName);
    }
}