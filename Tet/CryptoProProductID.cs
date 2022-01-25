using Microsoft.Win32;
using System;

namespace RegistryExporter
{
    public class CryptoProProductID
    {
        public string SerialNumber4 { get; private set; }
        public string SerialNumber5 { get; private set; }
        public string FileName { get; private set; }
        private void SetProductID()
        {
            RegistryKey localKey = Registry.LocalMachine;
            string pathToProducts = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products";
            string pathToVersion4 = @"\7AB5E7046046FB044ACD63458B5F481C\InstallProperties";
            string pathToVersion5 = @"\08F19F05793DC7340B8C2621D83E5BE5\InstallProperties";

            SerialNumber4 = GetID(localKey, pathToProducts, pathToVersion4);
            if (SerialNumber4 != string.Empty)
            {
                Printer.Info.CopyProductIDFinish("4.0");
            }
            SerialNumber5 = GetID(localKey, pathToProducts, pathToVersion5);
            if (SerialNumber5 != string.Empty)
            {
                Printer.Info.CopyProductIDFinish("5.0");
            }
        }

        private string GetID(RegistryKey localKey, string pathToProducts, string pathToVersion)
        {
            localKey = localKey.OpenSubKey(pathToProducts + pathToVersion);
            if (localKey == null)
            {
                return string.Empty;
            }
            object SerialNumber = localKey.GetValue("ProductID");
            SerialNumber = SerialNumber as string;
            if (SerialNumber == null)
            {
                return string.Empty;
            }
            else
            {
                return SerialNumber.ToString();
            }
        }
        private void SetFileName()
        {
            if (SerialNumber4 == string.Empty & SerialNumber5 == string.Empty)
            {
                FileName = "SerialNumbers(empty)";
            }
            else
            {
                Random rnumber = new Random();
                FileName = "SerialNumbers"+rnumber.Next().ToString();
            }
        }

        public CryptoProProductID()
        {
            SetProductID();
            SetFileName();
        }
    }
}


