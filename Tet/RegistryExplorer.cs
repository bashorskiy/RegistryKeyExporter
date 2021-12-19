using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace RegistryExporter
{
    public class RegistryExplorer
    {
        private bool _is64 = Environment.Is64BitOperatingSystem;
        public RegistryKey LocalKey { get; private set; }
        public string OSVersion { get; private set; }
        public string RegistryPathToKeys { get; private set; }
        public string SID { get; private set; }
        private void SetOsVersion()
        {
            string maj = Environment.OSVersion.Version.Major.ToString();
            string min = Environment.OSVersion.Version.Minor.ToString();
            OSVersion = maj + "." + min;
        }
        private void SetRegistryPathToKeysWithRegKey()
        {
            if (OSVersion == "6.3" || OSVersion == "6.2")
            {
                LocalKey = Registry.CurrentUser;
                if (_is64)
                {
                    RegistryPathToKeys = @"Software\Classes\VirtualStore\MACHINE\SOFTWARE\Wow6432Node\Crypto Pro\Settings\Users" + SID + @"\Keys";
                }
                else
                {
                    RegistryPathToKeys = @"Software\Classes\VirtualStore\MACHINE\SOFTWARE\Crypto Pro\Settings\Users" + SID + @"\Keys";
                }
            }
            else
            {
                LocalKey = Registry.LocalMachine;
                if (_is64)
                {
                    RegistryPathToKeys = @"SOFTWARE\wow6432Node\Crypto Pro\Settings\Users\" + SID + @"\Keys";
                }
                else
                {
                    RegistryPathToKeys = @"SOFTWARE\Crypto Pro\Settings\USERS\" + SID + @"\Keys";
                }
            }
        }
        public RegistryExplorer()
        {
            SID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            SetOsVersion();          
            SetRegistryPathToKeysWithRegKey();
        }
    }
}


