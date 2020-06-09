using System;
using System.Collections.Generic;
using System.Text;

namespace SMSServiceHost.Processors
{
    public  class NameProcessor : INameProcessor
    {
        private string _name;

        public NameProcessor(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
