using Microsoft.Win32;
using System;

namespace RegistryExporter
{
    public class RegistryExporter
    {
        private Key[] _keys=null;
        private RegistryKey _localKey;
        private string _registryPathToKeys;
        private string[] _valueNames;
        public RegistryExporter(string pathToKeys, RegistryKey registryKey)
        {
            _registryPathToKeys = pathToKeys;
            _localKey = registryKey;
            _valueNames = new string[]
            {
                "name.key",
                "header.key",
                "primary.key",
                "masks.key",
                "primary2.key",
                "masks2.key"
            };
        }

        public Key[] GetKeys()
        {
            ExportKeys(_localKey.OpenSubKey(_registryPathToKeys));
            return _keys;
        }

        private void ExportKeys(RegistryKey rkey)
        {         
            if (rkey is null)
            {
                Printer.Warnings.KeysNotFound();
                return;
            }
            string[] keyNames = rkey.GetSubKeyNames();            
            _keys = new Key[keyNames.Length];
            for (int i = 0; i < keyNames.Length; i++)
            {
                _keys[i] = new Key();
                _keys[i].SetKeyFullPath(_registryPathToKeys + "\\" + keyNames[i]);
                _keys[i].SetKeyName(keyNames[i]);
                GetHexes(rkey.OpenSubKey(keyNames[i]), i);
                Printer.Info.CopyKeys(_keys[i].GetKeyName());
            }
        }
        private void GetHexes(RegistryKey rkey, int keyIterator)
        {
            for (int i = 0; i < _valueNames.Length; i++)
            {
                _keys[keyIterator].SetValueNameAndHex(_valueNames[i], GetHexesNumb(rkey.GetValue(_valueNames[i])));
            }
        }
        private string[] GetHexesNumb(object keyHex)
        {
            byte[] keyHexes = (byte[])keyHex;
            string[] newHexes = new string[keyHexes.Length];
            for (int i = 0; i < keyHexes.Length; i++)
            {
                string hexNumb = Convert.ToString(keyHexes[i], 16);
                if (hexNumb.Length == 1)
                {
                    hexNumb = "0" + hexNumb;
                }
                newHexes[i] = hexNumb;
            }
            return newHexes;
        }
    }
}


