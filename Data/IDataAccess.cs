namespace Data
{
    public interface IDataAccess
    {
        string LoadData(string processedInfo);
        string SaveData(string processedName);
        public void SetDataName(string dataName);
    }
}