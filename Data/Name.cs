using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Name : IName
    {
        public string NameData { get; set; }
        public void SetDataName(string dataName)
        {
            NameData = dataName;
        }
    }
}
