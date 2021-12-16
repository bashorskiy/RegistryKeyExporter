using System.Collections.Generic;

namespace RegistryExporter
{
    public class Key
    {
        private string _keyFullPath;

        private string _keyName;
        private Dictionary<string, string[]> _valueNameAndHex = new Dictionary<string, string[]>(6);
           
        public void SetKeyName(string name)
        {
            _keyName = name;
        }
        public string GetKeyName()
        {
            return _keyName;
        }

        
        public void SetKeyFullPath(string path)
        {
            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine;
            _keyFullPath = registryKey.ToString() + "\\" + path;
        }
        public string GetKeyFullPath()
        {
            return _keyFullPath;
        }

        public void SetValueNameAndHex(string valueName, string[] hexes)
        {
            _valueNameAndHex.Add(valueName, hexes);
        }

        public Dictionary<string, string[]> GetValueNameAndHex()
        {
            return _valueNameAndHex;
        }

    }
}


