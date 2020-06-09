
namespace Data
{
    public class DataAccess : IDataAccess
    {
        private string _access;
        public IName Name { get; set; }

        public string Access
        {
            get { return _access; }
        }
        public string LoadData(string processedInfo)
        {
            return $"Loading Data {processedInfo}. Access: {_access}. Data name:{Name.NameData}";
        }

        public string SaveData(string processedName)
        {
            return $"Saving {processedName}. Data name:{Name.NameData}";
        }

        public void SetDataName(string dataName)
        {
            _access = "access " + dataName + " access";
            Name.SetDataName(dataName);
        }
    }
}
