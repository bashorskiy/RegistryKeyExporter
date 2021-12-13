using Microsoft.Win32;
using System;

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
                _registryPath = @"SOFTWARE\Wow6432Node\Crypto Pro\Settings\USERS\" + _SID + @"\Keys";
            }
            else
            {
                _registryPath = @"SOFTWARE\Crypto Pro\Settings\USERS\" + _SID + @"\Keys";
            }
        }
      
        public void PrintRegistry()
        {          
            RegistryKey rk = Registry.LocalMachine;
            rk = rk.OpenSubKey(_registryPath);
            PrintKeys(rk);
        }

        private void PrintKeys(RegistryKey rkey)
        {
            string[] keyNames = rkey.GetSubKeyNames();

            rkey = rkey.OpenSubKey(keyNames[0]);
            string[] keyFields =
            {
                "header.key",
                "masks.key",
                "masks2.key",
                "name.key",
                "primary.key",
                "primary2.key"
            };

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


