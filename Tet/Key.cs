using System.Collections.Generic;

namespace RegistryExporter
{
    public class Key
    {
        private string _keyFullPath;
     
        private string _keyName;
        private Dictionary<string, string[]> _valueNameAndHex = new Dictionary<string, string[]>(6);       
        
        public void SetValueNameAndHex(string valueName, string[]hexes)
        {
            _valueNameAndHex.Add(valueName, hexes);
        }

        public void SetKeyName(string name)
        {
            _keyName = name;
        }

        public void SetFullPath(string path)
        {
            _keyFullPath = path;
        }
    }
}


