using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace RegistryExporter
{
    public class RegistryExplorer
    {
        private Key[] _keys;
        private string[] _valueNames;
        private string _registryPath;
        public string SID { get; private set; }
        public RegistryExplorer()
        {
            SID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            if (Environment.Is64BitOperatingSystem)
            {
                _registryPath = @"SOFTWARE\wow6432Node\Crypto Pro\Settings\Users\" + SID + @"\Keys";
                Console.WriteLine("x64");
            }
            else
            {
                _registryPath = @"SOFTWARE\Crypto Pro\Settings\USERS\" + SID + @"\Keys";
                Console.WriteLine("x32");
            }
            _valueNames = new string[]
            {
                "name.key",
                "header.key",
                "primary.key",
                "masks.key",
                "primary2.key",
                "masks2.key"
            };
            Console.WriteLine(_registryPath);
        }

        public Key[] GetKeys()
        {
            RegistryKey localKey = Registry.LocalMachine;
            ExportKeys(localKey.OpenSubKey(_registryPath));
            return _keys;
        }


        private void ExportKeys(RegistryKey rkey)
        {
            string[] keyNames = rkey.GetSubKeyNames();
            _keys = new Key[keyNames.Length];
            for (int i = 0; i < keyNames.Length; i++)
            {
                _keys[i] = new Key();
                _keys[i].SetKeyFullPath(_registryPath + "\\" + keyNames[i]);
                _keys[i].SetKeyName(keyNames[i]);
                GetHexes(rkey.OpenSubKey(keyNames[i]), i);
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


