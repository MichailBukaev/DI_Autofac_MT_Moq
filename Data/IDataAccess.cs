namespace Data
{
    public interface IDataAccess
    {
        IName Name { get; set; }
        string LoadData(string processedInfo);
        string SaveData(string processedName);
        public void SetDataName(string dataName);
    }
}