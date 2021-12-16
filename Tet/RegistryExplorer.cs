﻿using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace RegistryExporter
{
    public class RegistryExplorer
    {
        private Key[] _keys;
        private string[] _valueNames;
        private string _registryPath;
        private string _SID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
        public RegistryExplorer()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                _registryPath = @"SOFTWARE\wow6432Node\Crypto Pro\Settings\Users\" + _SID + @"\Keys";
                Console.WriteLine("x64");
            }
            else
            {
                _registryPath = @"SOFTWARE\Crypto Pro\Settings\USERS\" + _SID + @"\Keys";
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
            for (int i = 0; i < keyNames.Length; i++)
            {
                GetHexes(rkey.OpenSubKey(keyNames[i]));
            }           
        }

        private void GetHexes(RegistryKey rkey)
        {       
            
            for (int i = 0; i < _valueNames.Length; i++)
            {
                SetHexNumb(rkey.GetValue(_valueNames[i]));
            }                     
        }

        private void SetHexNumb(object keyHex)
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
        }
    }
}


