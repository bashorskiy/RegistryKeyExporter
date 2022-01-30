using System;
using System.Collections.Generic;
using System.IO;

namespace RegistryExporter
{
    public class FileCreator
    {
        private readonly string _regEditorVersion = "Windows Registry Editor Version 5.00";
        private string _registryPathToKeys;
        private List<KeyFormatter> _templates;       

        private void SetTemplates(List<KeyFormatter> templates) => _templates = templates;
        private void SetRegistryPathToKeys(string registryPathToKeys)
        {
            if (string.IsNullOrEmpty(registryPathToKeys))
            {
                return;
            }
            Microsoft.Win32.RegistryKey localKey = Microsoft.Win32.Registry.LocalMachine;
            _registryPathToKeys = "[" + localKey.ToString() + "\\" + registryPathToKeys + "]";
        }
       
       
        public void CreateKeysRegFile(string pathToKeys, List<KeyFormatter> templates)
        {
            SetRegistryPathToKeys(pathToKeys);
            SetTemplates(templates);           
            Random random = new Random();
            string writePath = Path.Combine(Directory.GetCurrentDirectory(), "my keys" + random.Next().ToString() + ".txt");

            FileStream fs = new FileStream(writePath, FileMode.Create);
            byte[] bufferArray = System.Text.Encoding.Default.GetBytes(_regEditorVersion + "\n\n" + _registryPathToKeys + "\n\n");
            fs.Write(bufferArray, 0, bufferArray.Length);

            foreach (var item in _templates)
            {
                byte[] buffer = System.Text.Encoding.Default.GetBytes(item.FormatResult);
                fs.Write(buffer, 0, item.FormatResult.Length);
            }

            fs.Close();
            File.Copy(writePath, Path.ChangeExtension(writePath, ".reg"));            
            File.Delete(writePath);
            Printer.Info.CopyKeysFinish();
        }

        public void CreateProductIDTextFile(CryptoProProductID productID)
        {
            string writePath = Path.Combine(Directory.GetCurrentDirectory(), productID.FileName + ".txt");
            FileStream fs = new FileStream(writePath, FileMode.Create);
            byte[] bufferArray = System.Text.Encoding.Default.GetBytes("4.0= " + productID.SerialNumber4 + "\n5.0= " + productID.SerialNumber5);
            fs.Write(bufferArray, 0, bufferArray.Length);
            fs.Close();           
        }

    }
}



