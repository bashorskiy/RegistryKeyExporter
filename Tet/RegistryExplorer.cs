using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace RegistryExporter
{
    public class RegistryExplorer
    {
        private string _registryPath;
        private string _SID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
        public RegistryExplorer()
        {
            if(Environment.Is64BitOperatingSystem)
            {
                _registryPath = @"SOFTWARE\wow6432Node\Crypto Pro\Settings\Users\" + _SID + @"\Keys";
                Console.WriteLine("x64");
            }
            else
            {
                _registryPath = @"SOFTWARE\Crypto Pro\Settings\USERS\" + _SID + @"\Keys";
                Console.WriteLine("x32");
            }
            Console.WriteLine(_registryPath);
        }
      
        public void PrintRegistry()
        {          
            RegistryKey localKey = Registry.LocalMachine;
            RegistryKey rKey = localKey.OpenSubKey(_registryPath);
            PrintKeys(rKey);            
        }

       
        private void PrintKeys(RegistryKey rkey)
        {
            string[] keyNames = rkey.GetSubKeyNames();
            rkey = rkey.OpenSubKey(keyNames[0]);          
            object keyHex = rkey.GetValue("header.key");
            byte[] barr = (byte[])keyHex;
            foreach (var item in barr)
            {
                string tempHex = Convert.ToString(item, 16);
                tempHex = AddZeroBeforeSingleSymbol(tempHex);
                Console.WriteLine(tempHex);
            }
        }

        private string AddZeroBeforeSingleSymbol(string letter)
        {
            string hexNumb = letter.ToLower();
            if (hexNumb.Length == 1)
            {
                hexNumb = "0" + hexNumb;
            }
            return hexNumb;
        }
    }
}


