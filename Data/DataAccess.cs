using System;

namespace Data
{
    public class DataAccess : IDataAccess
    {
        private readonly IName _name;
        private string _access;
        public DataAccess(IName name)
        {
            _name = name;
        }
        public string LoadData(string processedInfo)
        {
            return $"Loading Data {processedInfo}. Access: {_access}. Data name:{_name.NameData}";
        }

        public string SaveData(string processedName)
        {
            return $"Saving {processedName}. Data name:{_name.NameData}";
        }

        public void SetDataName(string dataName)
        {
            _access = "access " + dataName + " access";
            _name.SetDataName(dataName);
        }
    }
}
